<template>
  <div id="edit-room" class="modal fade bd-example-modal-lg" role="dialog">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-header title-booking">
          <span class="modal-title">
            <i class="fa fa-edit"></i>
            Chỉnh sửa&nbsp;{{roomName}}
          </span>
          <button type="button" class="close" data-dismiss="modal">×</button>
        </div>
        <div class="modal-body">
          <div class="form-group row">
            <label class="col-md-3 col-sm-3 col-md-3 col-sm-3 col-3 col-form-label col-form-label-sm text-right">
              Tên phòng&nbsp;<code>(*)</code>:
            </label>
            <div class="col-md-6 col-sm-6 col-md-6 col-sm-6 col-9">
              <input type="text" class="form-control" placeholder="Tên phòng" v-model="roomName">
            </div>
          </div>
          <div class="form-group row">
            <label class="col-md-3 col-sm-3 col-3 col-form-label col-form-label-sm text-right">
              Khu vực&nbsp;<code>(*)</code>:
            </label>
            <div class="col-md-6 col-sm-6 col-9">
              <select class="custom-select" v-model="areaID">
                <option v-for="item in listArea" :value="item.AreaID">{{item.AreaName}}</option>
              </select>
            </div>
          </div>
          <div class="form-group row">
            <label class="col-md-3 col-sm-3 col-3 col-form-label col-form-label-sm text-right">
              Chỗ ngồi&nbsp;<code>(*)</code>:
            </label>
            <div class="col-md-6 col-sm-6 col-9">
              <input type="number" class="form-control" placeholder="Chỗ ngồi" v-model="seat">
            </div>
          </div>

          <div class="form-group row">
            <label class="col-md-3 col-sm-3 col-3 col-form-label col-form-label-sm text-right">
              Thiết bị:
            </label>
            <div class="col-md-6 col-sm-6 col-9">
              <div class="form-check form-check-inline">
                <input class="form-check-input" type="checkbox" id="checkbox_video" v-model="videoCall" value="true">
                <label class="form-check-label" for="radio_video">Video Call</label>
              </div>
              <div class="form-check form-check-inline">
                <input class="form-check-input" type="checkbox" id="checkbox_phone" v-model="phoneCall" value="true">
                <label class="form-check-label" for="radio_phone">Phone Call</label>
              </div>
            </div>

          </div>

          <div class="form-group row">
            <label class="col-md-3 col-sm-3 col-3 col-form-label col-form-label-sm text-right">
              Trạng thái:
            </label>
            <div class="col-md-6 col-sm-6 col-9">
              <div class="form-check form-check-inline">
                <input class="form-check-input" type="radio" v-model="visible" value="true">
                <label class="form-check-label" for="radio_ready">Hiện</label>
              </div>
              <div class="form-check form-check-inline">
                <input class="form-check-input" type="radio" v-model="visible" value="false">
                <label class="form-check-label" for="radio_busy">Tạm ẩn</label>
              </div>
            </div>
          </div>

          <div class="form-group row">
            <label class="col-md-3 col-sm-3 col-3 col-form-label col-form-label-sm text-right">
              Hình đại diện:
            </label>
            <div class="col-md-6 col-sm-6 col-9 avatar-room">
              <img v-if="avatar" class="img-fluid img-circle" :src="avatar" />
              <img v-else class="img-fluid img-circle" :src="nopic" />
              <input type="file" @change="onFileChanged" class="btn btn-sm btn-outline-warning">
            </div>
          </div>

          <div class="form-group row">
            <label class="col-md-3 col-sm-3 col-3 col-form-label col-form-label-sm text-right">
              Ghi chú (Nếu có):
            </label>
            <div class="col-md-6 col-sm-6 col-9">
              <div class="input-group">
                <input class="form-control" v-model="desc" />
              </div>
              <small class="form-text text-danger">Vui lòng điền đầy đủ thông tin trong các trường có (*)</small>
            </div>
          </div>
          <div class="text-center">
            <button id="btnBooking" type="submit" @click="AdminUpdateRoom($event)" class="btn btn-success mr-2">
              <i class="fa fa-save"></i>&nbsp;Lưu lại
            </button>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>

<script>
  import EventBus from "../EventBus";
  import axios from "axios";
  export default {
    components: {
    },
    data() {
      return {
        avatar: "",
        areaID: 0,
        seat: 0,
        listArea: {},
        desc: "",
        numberPeople: "",
        roomName: "",
        roomID: "",
        phoneCall: null,
        videoCall: null,
        visible: true,
        file: null,
        createBy: "",
        nopic: "/Content/Images/ImageFound.png",
      }
    },
    methods: {
      //On change Func
      onChangeArea(e) {
        this.areaName = e.target.value;
      },

      onFileChange(e) {
        var files = e.target.files || e.dataTransfer.files;
        if (!files.length)
          return;
        this.createImage(files[0]);
      },

      onFileChanged(event) {
        let seft = this;
        seft.file = event.target.files[0];
        let formData = new FormData();
        formData.append("file", seft.file);

        axios.post("/Room/Uploadmage", formData, {
          headers: {
            "Content-Type": "multipart/form-data"
          }
        })
          .then(res => {
            seft.avatar = res.data;
          })
          .catch(error => {
            AlertDanger("Upload avatar thất bại, vui lòng chọn file ảnh và thử lại!");
            return;
          });
      },

      AdminUpdateRoom() {
        let seft = this;
        if (seft.roomName == "") {
          AlertWarning("Vui lòng nhập tên phòng!");
          return;
        }
        if (seft.areaID == 0) {
          AlertWarning("Vui lòng chọn khu vực của phòng!");
          return;
        }
        if (seft.seat == 0) {
          AlertWarning("Vui lòng nhập sức chứa của phòng!");
          return;
        }

        let data = {
          roomID: seft.roomID, roomName: seft.roomName, areaID: seft.areaID, seat: seft.seat,
          phoneCall: seft.phoneCall, videoCall: seft.videoCall, visible: seft.visible, desc: seft.desc, avatar: seft.avatar, createBy: seft.createBy
        }
        axios.post("/Room/UpdateRoomDetail", data).then(res => {
          if (res.data.status == 1) {
            AlertSuccess("Dữ liệu đã được cập nhật thành công!");
            $("#edit-room").modal("hide");
            EventBus.$emit("BindRoomHome", true);
            return;
          }
          else {
            AlertDanger("Rất tiếc, dữ liệu chưa được cập nhật, vui lòng kiểm tra và thử lại!");
            return;
          }
        })
          .catch(error => {
            AlertDanger("Lỗi hệ thống, vui lòng thử lại sau!");
            return;
          });
      },

    },
    mounted() {

    },

    created() {
      let seft = this;
      EventBus.$on("EditRom", item => {
        seft.room      = item;
        seft.visible   = item.Visible;
        seft.roomID    = item.RoomID;
        seft.roomName  = item.RoomName;
        seft.areaID    = item.AreaID;
        seft.avatar    = item.Avatar;
        seft.phoneCall = item.PhoneCall;
        seft.videoCall = item.VideoCall;
        seft.seat      = item.Seat;
        seft.createBy  = seft.$cookies.get('user').FullName;
        $("#edit-room").modal("show");
      });
      axios.post("/ListArea/GetAllArea").then(res => {
        seft.listArea                             = res.data;
      });
    }
  }
</script>
