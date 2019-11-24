
<template>
  <div>
    <div class="row mt-2">
      <admin-search-user-component></admin-search-user-component>
      <div class="col-md-3 col-sm-12 col-12 mt-3 pull-left">
        <button class="btn btn-sm btn-primary pull-right" @click="addUser()">
          <i class="fa fa-plus"></i> Thêm người dùng
        </button>
      </div>
    </div>
    <div class="clearfix"></div>
    <!--Nhúng Tìm kiếm  -->


    <div class="main-box clearfix">
      <div class="table-responsive">
        <table class="table user-list">
          <thead>
            <tr>
              <th><span>Người dùng</span></th>
              <th><span>Người tạo</span></th>
              <th><span>Trạng thái</span></th>
              <th><span>Email</span></th>
              <th><span>Thao tác</span></th>
            </tr>
          </thead>
          <tbody v-if="listUser.length>0">
            <tr v-for="(item, index) in listUser">
              <td>
                <img v-if="item.userAvatar" class="img-circle img-responsive" :src="item.userAvatar" alt="avatar">
                <img v-else class="img-circle img-responsive" :src="nopic" alt="avatar">
                <a href="#" class="user-link">{{item.fullName}}</a><br />
                <span class="user-subhead">{{item.userID}}</span>
              </td>
              <td>
                {{item.createBy}}
              </td>
              <td class="text-center">
                <span class="badge badge-success" v-if="item.visible==true">Hoạt động</span>
                <span class="badge badge-danger" v-else>Tạm ẩn</span>
              </td>
              <td>
                <a href="#">{{item.email}}</a>
              </td>
              <td style="width: 20%;">
                <a class="btn btn-sm btn-warning mt-1" href="javascript:" @click="EditUserDetail(item.userID)">
                  <i class="fa fa-edit"></i>&nbsp;Chỉnh sửa
                </a>
                <a href="javascript:" class="btn btn-sm btn-danger delete-booking mt-1" @click="DeleteUser(item.userID)">
                  <i class="fa fa-trash-o" aria-hidden="true"></i>&nbsp;Xóa
                </a>
              </td>
            </tr>

          </tbody>
        </table>
      </div>
    </div>

    <div class="col-12 alert alert-danger mt-2" role="alert" v-if="isNoneData">
      <strong>Thông báo!&nbsp;</strong>Không tìm thấy dữ liệu!
    </div>
    <!-- add-user-component -->
    <admin-add-user-component></admin-add-user-component>

  </div>
</template>

<script>
  import AdminSearchUserComponent from './AdminSearchUserComponent.vue';
  import AdminAddUserComponent from './AdminAddUserComponent.vue';
  import axios from 'axios';
  import EventBus from '../EventBus';
  import { fail } from 'assert';
  import { debug } from 'util';
  export default {
    components: {
      AdminSearchUserComponent,
      AdminAddUserComponent
    },
    data() {
      return {
        isNoneData: false,
        isStatus: true,
        itemUser: {},
        listUser: {},
        nopic: "/Content/Images/ImageFound.png",
      }
    },
    methods: {
      SearchUser(fullName, facultyID) {
        ShowLoading();
        axios.post('/User/SearchAll', { fullName: this.fullName, facultyID: this.facultyID })
          .then(res => {
            this.listUser = res.data;
            HideLoading();
          })
          .catch(error => {
            AlertDanger("Lỗi hệ thống, vui lòng thử lại sau!");
            HideLoading();
            return false;
          });
      },
      convertDate(date) {
        var nowDate = new Date(parseInt(date.substr(6)));
        return nowDate.format("dd/mm/yyyy");
      },
      convertTime(date) {
        var nowDate = new Date(parseInt(date.substr(6)));
        return nowDate.format("HH:MM");
      },

      DeleteUser: function (userID) {
        let seft = this;
        if (seft.$cookies.get('user') == null) {
          AlertWarning("Vui lòng đăng nhập để thực hiện chức năng này!");
          return false;
        }
        else if (!seft.$cookies.get('user').Roles) {
          AlertWarning("Xin lỗi, bạn chưa được quyền thực hiện chức năng này!");
          return false;
        }
        else if (userID == seft.$cookies.get('user').UserID) {
          AlertDanger("Bạn không được xóa chính bạn !");
          return false;
        }
        else {
          $.confirm({
            title: 'Cảnh báo!',
            content: 'Bạn có chắc chắn muốn nguời dùng này không ?',
            type: 'orange',
            typeAnimated: true,
            theme: "material",
            buttons: {
              Delete: {
                text: 'Xóa',
                btnClass: 'btn-red',
                action: function () {
                  axios.post("/User/DeleteUser", { userID: userID })
                    .then(res => {
                      if (res.data.status == 1) {
                        AlertSuccess("Xin chúc mừng đã xóa dữ liệu thành công!");
                        EventBus.$emit("BindUserHome", true);
                      }
                      else {
                        AlertWarning("Rất tiếc dữ liệu chưa được xóa, vui lòng kiểm tra lại!");
                      }
                    })
                    .catch(error => {
                      AlertDanger("Lỗi hệ thống, vui lòng thử lại sau!");
                      return;
                    });
                }
              },
              close: function () {
              }
            }
          });
        }
      },
      EditUserDetail: function (userID) {
        let seft = this;
        if (seft.$cookies.get('user') == null) {
          AlertWarning("Vui lòng đăng nhập để thực hiện chức năng này!");
          return false;
        }
        else if (!seft.$cookies.get('user').Roles) {
          AlertWarning("Xin lỗi, bạn chưa được quyền thực hiện chức năng này!");
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

      addUser: function () {
        if (this.$cookies.get('user') == null) {
          AlertWarning("Vui lòng đăng nhập để thực hiện chức năng này!");
          return false;
        }
        else if (!this.$cookies.get('user').Roles) {
          AlertWarning("Xin lỗi, bạn chưa được quyền thực hiện chức năng này!");
          return false;
        }
        else {
          $("#add-user").modal("show");
        }
      },
    },
    watch: {

    },
    created() {
      let seft = this;
      ShowLoading();
      EventBus.$on('BindSearchAdminUser', (item) => {
        seft.listUser = item;
        HideLoading();
        if (item == 0) {
          seft.isNoneData = true;
        }
        else {
          seft.isNoneData = false;
        }
      });
    }
  }
</script>
