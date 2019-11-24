<template>
  <div id="edit-area" class="modal fade bd-example-modal-lg" role="dialog">
    <div class="modal-dialog modal-lg">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header title-booking">
          <span class="modal-title">
            <i class="fa fa-edit"></i>
            Chỉnh sửa khu vực&nbsp;{{areaName}}
          </span>
          <button type="button" class="close" data-dismiss="modal">×</button>
        </div>
        <div class="modal-body">
          <div class="form-group row">
            <label class="col-md-3 col-sm-3 col-md-3 col-sm-3 col-3 col-form-label col-form-label-sm text-right">
              Tên khu vực&nbsp;<code>(*)</code>:
            </label>
            <div class="col-md-6 col-sm-6 col-md-6 col-sm-6 col-9">
              <input type="text" class="form-control" placeholder="Tên khu vực" v-model="areaName">
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
              Mô tả (Nếu có):
            </label>
            <div class="col-md-6 col-sm-6 col-9">
              <div class="input-group">
                <textarea class="form-control" id="desc" v-model="desc" />
              </div>
              <small class="form-text text-danger">Vui lòng điền đầy đủ thông tin trong các trường có (*)</small>
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

          <div class="text-center">
            <button  id="btnBooking" class="btn btn-success mr-2" @click="UpdateArea($event)">
              <i class="fa fa-save"></i> Lưu lại
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
  import { create } from "domain";
  export default {
    components: {

    },
    data() {
      return {
        avatar: "/Content/Images/ImageFound.png",
        nopic: "/Content/Images/ImageFound.png",
        desc: "",
        areaName: "",
        visible: true,
        file: null,
        createBy: "",
        areaID: 0,
      }
    },
    methods: {
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

      UpdateArea() {
        let seft = this;
        if (!seft.$cookies.isKey("user")) {
          AlertWarning("Vui lòng đăng nhập để thực hiện chức năng đặt phòng");
          return;
        }
        if (seft.areaName == "") {
          AlertWarning("Vui lòng nhập tên khu vực!");
          return;
        }

        else {
          seft.create = seft.$cookies.get('user').FullName;
        }
        let data = { areaID: seft.areaID, areaName: seft.areaName, avatar: seft.avatar, desc: seft.desc, visible: seft.visible, createBy: seft.createBy }
        axios.post("/ListArea/UpdateArea", data)
          .then(res => {
            if (res.data.status == 1) {
              AlertSuccess("Xin chúc mừng dữ liệu đã được cập nhật thành công!");
              $("#edit-area").modal("hide");
              EventBus.$emit("BinArea", true);
              return;
            }
            else {
              AlertDanger("Rất tiếc, dữ liệu chưa được cập nhật, vui lòng kiểm tra và thử lại!");
              return;
            }
          })
          .catch(error => {
            AlertDanger("Rất tiếc lỗi hệ thống,dữ liệu chưa được cập nhật vui lòng thử lại sau!");
            return;
          });
      },
    },
    mounted() {

    },

    created() {
      let seft    = this;
      EventBus.$on("EditArea", item  => {
         seft.visible                = item.Visible;
        seft.areaID                  = item.AreaID;
        seft.areaName                = item.AreaName;
        seft.avatar                  = item.Avatar;
        seft.desc                    = item.Description;
        seft.visible                 = item.Visible;
        seft.createBy                = seft.$cookies.get('user').FullName;
        $("#edit-area").modal("show");
      });
    }
  }
</script>
