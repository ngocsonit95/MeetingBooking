
<template>
  <div>
    <main>
      <div class="wrapper container">
        <div class="row">
          <nav class="navbar navbar-expand-lg navbar-dark" id="menu-top">
            <a><img class="img-fluid logo" src="/Content/Images/logo.png" /></a>
            <button class="navbar-toggler collapsed" type="button" data-toggle="collapse" data-target="#navbarBooking" aria-controls="navbarBooking" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>

            <div class="navbar-collapse collapse" id="navbarBooking">
              <ul class="navbar-nav mr-auto">

                <li class="nav-item">
                  <router-link to="/"
                               class="nav-link"
                               exact>Trang chủ</router-link>
                </li>
                <li class="nav-item">
                  <router-link class="nav-link" :to="{ name: 'report'}">Thống kê</router-link>
                </li>
                <li class="nav-item" v-if="checkAcount">
                  <router-link class="nav-link" :to="{ name: 'list-area'}">Khu vực</router-link>
                </li>
                <li class="nav-item" v-if="checkAcount">
                  <router-link class="nav-link" :to="{ name: 'list-room'}">Phòng</router-link>
                </li>

                <li class="nav-item" v-if="checkAcount">
                  <router-link class="nav-link" :to="{ name: 'list-faculty'}">Khoa</router-link>
                </li>
                <li class="nav-item" v-if="checkAcount">
                  <router-link class="nav-link" :to="{ name: 'list-user'}">Người dùng</router-link>
                </li>
              </ul>

              <span id="clock"></span>
              <div class="btn-group user" v-show="user">
                <a href="#" class="dropdown-toggle user-name" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  <img class="img-fluid img-circle" :src="avatar" alt="Avatar" width="40" style="border-radius: 50%" />
                  {{user!=null?user.FullName:"No Name" }}
                </a>
                <ul class="dropdown-menu dropdown-menu-right box-user" aria-labelledby="dLabel">
                  <li class="ddmenu">
                    <a href="javascript:" @click="EditUserDetail(userID)">
                      <img alt="man" src="/Content/icon/mnprofile.png">
                      Cá nhân
                    </a>
                  </li>

                  <li role="separator" class="divider"></li>
                  <li class="ddmenu">
                    <a href="http://ktkt.edu.vn/c9i4/ban-tin/gioi-thieu-ve-dai-hoc-kinh-te-ky-thuat-binh-duong" target="_blank">
                      <img alt="man" src="/Content/icon/mntb.png">
                      Giới thiệu
                    </a>
                  </li>

                  <li role="separator" class="divider"></li>
                  <li class="ddmenu">
                    <a href="javascript:" data-toggle="modal" data-target="#change-password">
                      <img alt="man" src="/Content/icon/mnpass.png">
                      Đổi mật khẩu
                    </a>
                  </li>
                  <li class="ddmenu" style="display:none;">
                    <a href="javascript:" id="actionchangeimage">

                      <img alt="man" src="/Content/icon/mnimg.png">
                      Đổi hình đại diện
                    </a>
                  </li>
                  <li role="separator" class="divider"></li>
                  <li class="ddmenu">
                    <a href="javaScript:void(0);" @click="Logout()">

                      <img alt="man" src="/Content/icon/mnexit.png">
                      Đăng xuất
                    </a>
                  </li>
                </ul>
              </div>
              <div class="btn-group user" v-show="user==null">
                <a href="javaScript:void(0);" class="user-name" @click="OpenModalLogin()">
                  Đăng nhập
                </a>
              </div>
            </div>
          </nav>
        </div>
        <!--Dùng Chung -->
        <!-- =======router view========= -->
        <router-view></router-view>

        <div class="footer">
          <span class="pull-left">
            © Copyright 2019 - IT TEAM

          </span>
          <span class="pull-right">
            Powered by IT TEAM D15C02A
            <img src="/Content/Images/createby.gif" />
          </span>
        </div>
      </div>
    </main>

    <!-- #region Login Modal -->

    <div id="login" class="modal fade in" role="dialog">
      <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
          <form>
            <div class="modal-header title-login">
              <span class="modal-title">
                <i class="fa fa-user-circle"></i> &nbsp;
                Đăng nhập
              </span>
              <button type="button" class="close" data-dismiss="modal">×</button>
            </div>
            <div class="modal-body">
              <div class="form-group row mb-3 mt-4">
                <div class="col-12">
                  <input v-model="username" type="text" class="form-control" placeholder="UserName" v-on:keyup.enter="Login()" autocomplete="off">
                </div>
              </div>
              <div class="form-group row mb-4">
                <div class="col-12">
                  <input v-model="password" type="password" class="form-control" placeholder="Password" v-on:keyup.enter="Login()" autocomplete="off">
                </div>
              </div>
              <div class="text-center">
                <button type="button" class="btn btn-success mr-2" @click="Login()">
                  <i class="fa fa-sign-in"></i>&nbsp;Đăng nhập
                </button>
                <button type="reset" value="Reset" class="btn btn-danger" @click="ClearForm()">
                  <i class="fa fa-remove"></i>&nbsp;Làm lại
                </button>
              </div>
            </div>
          </form>

        </div>
      </div>
    </div>

    <!-- #endregion -->
    <!-- #region Meeting Booking -->

    <modal-booking-component></modal-booking-component>

    <!-- #endregion -->
    <!-- #region Calendar Booking-->

    <calendar-booking-component></calendar-booking-component>

    <!-- #endregion -->
    <!-- Modal Detail -->
    <modal-detail-component></modal-detail-component>
    <!-- #endregion -->

    <!-- #region Meeting Booking -->

    <edit-booking-component></edit-booking-component>

    <!-- #endregion -->
    <!-- Add Room -->
    <add-room-component></add-room-component>
    <!-- #endregion -->
    <!-- edit-user-component -->
    <admin-edit-user-component></admin-edit-user-component>
    <!-- #endregion -->
    <!-- ChangePass -->
    <!-- #region ChangePassword Modal -->
    <change-password-component></change-password-component>
    <!-- #endregion -->

    <div id="back-top">
      <button class="btn btn-danger">
        <i class="fa fa-angle-up"></i>
      </button>
    </div>
  </div>
</template>

<script>

  import ModalBookingComponent from './bookdetail/ModalBookingComponent.vue'
  import EditBookingComponent from './bookdetail/EditBookingComponent.vue'
  import CalendarBookingComponent from './bookdetail/CalendarBookingComponent.vue'
  import ModalDetailComponent from './bookdetail/ModalDetailComponent.vue'
  import AddRoomComponent from './adminroom/AddRoomComponent.vue'
  import ChangePasswordComponent from './ChangePasswordComponent.vue'
  import AdminListAreaComponent from './adminarea/AdminListAreaComponent.vue'
  import AdminListFacultyComponent from './adminfaculty/AdminListFacultyComponent.vue'
    import AdminEditUserComponent from './adminuser/AdminEditUserComponent.vue';
  import EventBus from "./EventBus";
  import axios from "axios";

  export default {
    components: {
      ModalBookingComponent,
      EditBookingComponent,
      CalendarBookingComponent,
      ModalDetailComponent,
      AddRoomComponent,
      AdminListAreaComponent,
      AdminListFacultyComponent,
      ChangePasswordComponent,
       AdminEditUserComponent,
    },
    data() {
      return {
        username: "",
        password: "",
        avatar: "/Content/Images/nopic.png",
        userID: null,
        checkAcount: false,
        user: null,
      }
    },
    methods: {
      Login: function () {
        let seft = this;
        if (seft.username == "") {
          AlertWarning("Vui lòng nhập tên đăng nhập");
          return;
        }
        if (seft.password == "") {
          AlertDanger("Vui lòng nhập mật khẩu");
          return;
        }
        axios.post("/User/Login", { username: seft.username, password: seft.password }).then(res => {
          if (res.data != null && res.data != "") {
            $("#login").modal("hide");
            seft.user = res.data;
            seft.$cookies.set('user', res.data);
            // print user name
            seft.ClearForm();
            EventBus.$emit("ButtonEditRoom", true);
            window.location.reload();
          }
          else {
            AlertWarning("Tài khoản không hoặc mật khẩu không đúng, vui lòng kiểm tra lại!");
          }
        });
      },
      Logout: function () {
        let seft = this;
        axios.get("/User/Logout").then(res => {
          if (res.data == true) {
            seft.user = null;
            seft.$cookies.remove("user");
            EventBus.$emit("ButtonEditRoom", true);
            window.location.reload();
          }
        });
      },
      OpenModalLogin: function () {
        $("#login").modal("show");
      },
      EditUserDetail: function (userID) {
        let seft = this;
        if (seft.$cookies.get('user') == null) {
          AlertWarning("Vui lòng đăng nhập để thực hiện chức năng này!");
          return false;
        }
        else {
          axios.post("/User/GetDetailUser", { userID: userID }).then(res => {
            seft.itemUser = res.data;
            EventBus.$emit("EditUser", seft.itemUser);
          }).catch(error => {
            AlertDanger("Lỗi hệ thống, vui lòng thử lại sau!");
            return;
          });
        }
      },
      ClearForm: function () {
        //Clear Form
        this.username = "";
        this.password = "";
      }
    },
    beforeCreate() {

    },
    mounted() {

    },
    created() {
      let seft = this;
      seft.user = seft.$cookies.get('user');
      if (seft.$cookies.get('user')) {
        seft.avatar = seft.$cookies.get('user').Avatar;
        seft.userID = seft.$cookies.get('user').UserID;
      }
      if (seft.$cookies.get('user').Roles) {
        seft.checkAcount = true;
        EventBus.$emit("ButtonEditRoom", true);
      }
    }
  };
</script>

