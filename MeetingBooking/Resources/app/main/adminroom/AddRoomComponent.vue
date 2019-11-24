<template>
  <div id="add-room" class="modal fade bd-example-modal-lg" role="dialog">
    <div class="modal-dialog modal-lg">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header title-booking">
          <span class="modal-title">
            <i class="fa fa-plus"></i>
            Thêm phòng
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
                <option value="0">..: Chọn khu vực :..</option>
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
              <img class="img-fluid img-circle" :src="avatar" />
              <input type="file" @change="onFileChanged" class="btn btn-sm btn-outline-warning">
            </div>
          </div>
          <div class="form-group row">
            <label class="col-md-3 col-sm-3 col-3 col-form-label col-form-label-sm text-right">
              Ghi chú(Nếu có)
            </label>
            <div class="col-md-6 col-sm-6 col-9">
              <div class="input-group">
                <input class="form-control" id="desc" v-model="desc"/>
              </div>
              <small class="form-text text-danger">Vui lòng điền đầy đủ thông tin trong các trường có (*)</small>
            </div>
          </div>

          <div class="text-center">
            <button class="btn btn-success mr-2" @click="AddRoom($event)"><i class="fa fa-save"></i>&nbsp;Thêm phòng</button>
            <button class="btn btn-warning" @click="ClearForm()"><i class="fa fa-remove"></i>&nbsp;Làm lại</button>
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
        avatar: "/Content/Images/ImageFound.png",
        areaID: 0,
        seat: 0,
        listArea: {},
        desc: "",
        numberPeople: 0,
        roomName: "",
        roomID: 0,
        phoneCall: null,
        videoCall: null,
        visible: true,
        file: null,
        createBy: "",
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

      AddRoom() {
        let seft = this;
        if (seft.roomName == "") {
          AlertWarning("Vui lòng nhập tên phòng!");
          return;
        }
        if (seft.areaID == 0) {
          AlertWarning("Vui lòng chọn khu vực phòng!");
          return;
        }
        if (seft.seat <= 0) {
          AlertWarning("Vui lòng nhập số lượng chỗ ngồi của phòng phù hợp!");
          return;
        }
        let data = {
          roomID: seft.roomID, roomName: seft.roomName, areaID: seft.areaID, seat: seft.seat,
          phoneCall: seft.phoneCall, videoCall: seft.videoCall, visible: seft.visible, desc: seft.desc, avatar: seft.avatar, createBy: seft.createBy
        }
        axios.post("/Room/AddRoom", data).then(res => {
          // Reset input control
          if (res.data.status == 1) {
            AlertSuccess("Dữ liệu đã được cập nhật thành công!");
            $("#add-room").modal("hide");
            EventBus.$emit("BindRoomHome", true);
            seft.ClearForm();
            return;
          }
          if (res.data.status == 2) {
            AlertWarning("Rất tiếc tên phòng này đã tồn tại, vui lòng nhập tên phòng khác!");
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

      ClearForm() {
        let seft       = this;
        seft.areaName  = "";
        seft.avatar    = "/Content/Images/ImageFound.png";
        seft.desc      = "";
        seft.areaID    = 0;
        seft.seat      = 0;
        seft.roomName  = "";
        seft.roomID    = 0;
        seft.phoneCall = null;
        seft.videoCall = null;
        seft.visible   = true;
      }
    },
    mounted() {

    },

    created() {
      let seft = this;
      seft.createBy = seft.$cookies.get('user').FullName;
      axios.post("/ListArea/GetAllArea").then(res => {
        seft.listArea = res.data;
      });
    }
  }

</script>
