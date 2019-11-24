<template>
  <div id="change-password" class="modal fade in" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <form>
          <div class="modal-header title-login">
            <span class="modal-title">
              <i class="fa fa-user-circle"></i> &nbsp;
              Đổi mật khẩu
            </span>
            <button type="button" class="close" data-dismiss="modal">×</button>
          </div>
          <div class="modal-body">
            <div class="form-group row mb-3 mt-4">
              <div class="col-12">
                <input v-model="fullName" type="text" disabled class="form-control" placeholder="Họ tên" autocomplete="off">
              </div>
            </div>
            <div class="form-group row mb-3 mt-4">
              <div class="col-12">
                <input v-model="password" type="password" class="form-control" placeholder="Mật khẩu cũ" v-on:keyup.enter="Change()" autocomplete="off">
              </div>
            </div>
            <div class="form-group row mb-3 mt-4">
              <div class="col-12">
                <input v-model="newPassword" type="password" class="form-control" placeholder="Mật khẩu mới" v-on:keyup.enter="Change()" autocomplete="off">
              </div>
            </div>
            <div class="form-group row mb-4">
              <div class="col-12">
                <input v-model="rePassword" type="password" class="form-control" placeholder="Xác nhận mật khẩu" v-on:keyup.enter="Change()" autocomplete="off">
              </div>
            </div>
            <div class="text-center">
              <button type="button" class="btn btn-success mr-2" @click="Change()">
                <i class="fa fa-recycle"></i>&nbsp;Đổi mật khẩu
              </button>
              <button type="button" class="btn btn-danger" @click="ClearForm()">
                <i class="fa fa-close"></i>&nbsp;Làm lại
              </button>
            </div>
          </div>
        </form>

      </div>
    </div>
  </div>
</template>
<script>
  import EventBus from "./EventBus";
  import axios from 'axios';
  import { fileURLToPath } from "url";
  import { fail } from 'assert';
  import { debug } from 'util';
  export default {
    components: {
    },
    data() {
      return {
        password: "",
        newPassword: "",
        rePassword: "",
        fullName: "",
        createBy: "",
      }
    },
    methods: {
      Change: function () {
        let seft = this;
        if (seft.password == "") {
          AlertWarning("Vui lòng nhập mật khẩu cũ");
          return;
        }
        if (seft.newPassword == "") {
          AlertWarning("Vui lòng nhập nhập mật khẩu mới");

          return;
        }
        if (seft.rePassword == "") {
          AlertWarning("Vui lòng xác nhận mật khẩu");
          return;
        }
        if (seft.newPassword != seft.rePassword) {
          AlertWarning("Rất tiếc, mật khẩu cũ và mật khẩu mới không khớp, vui lòng kiểm tra lại!");
          return;
        }
        axios.post("/User/ChangePass", { userID: seft.userID, password: seft.password, newPassword: seft.newPassword, createBy: seft.createBy }).then(res => {
          if (res.data.status == 1) {
            seft.ClearForm();
            $("#change-password").modal("hide");
            AlertSuccess("Mật khẩu đã được thay đổi, vui lòng tiến hành đăng nhập lại!");
            axios.get("/User/Logout").then(res => {
              if (res.data == true) {
                seft.user = null;
                seft.$cookies.remove("user");
                window.location.reload();
              }
            });
            return false;
          }
          if (res.data.status == 2) {
            AlertWarning("Vui lòng đăng nhập để tiến hành đổi mật khẩu");
            return false;
          }
          if (res.data.status == 3) {
            AlertWarning("Mật khẩu cũ của bạn không khớp, vui lòng kiểm tra lại!");
            return false;
          }
          else {
            AlertDanger("Rất tiếc dữ liệu chưa được cập nhật, vui lòng thử kiểm tra và thử lại!");
            return false;
          }
        }).catch(error => {
          AlertDanger("Lỗi hệ thống, vui lòng thử lại sau!");
          return false;
        });
      },

      ClearForm: function () {
        //Clear Form
        this.password = "";
        this.newPassword = "";
        this.rePassword = "";
      }
    },
    beforeCreate() {

    },
    mounted() {
      //document.title = this.$route.meta.title;
    },
    created() {
      this.createBy = this.$cookies.get('user').FullName;
      this.fullName = this.$cookies.get('user').FullName;
      this.userID = this.$cookies.get('user').UserID;

    }
  };
</script>
