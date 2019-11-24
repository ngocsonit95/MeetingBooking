
<template>
  <div>
    <div class="col-12 mt-2">
      <button class="btn btn-sm btn-primary pull-right" href="#" @click="addRoom()">
        <i class="fa fa-plus"></i> Thêm phòng
      </button>
    </div>
    <div class="clearfix"></div>
    <!--Nhúng Tìm kiếm  -->
    <admin-search-room-component></admin-search-room-component>

    <div class="card-columns listroom" v-if="listRoom.length>0">
      <div class="card meeting-group box-shadow" v-for="(item, index) in listRoom">
        <!--Hiển thị tên phòng và trạng thái "Sẳn sàng/Không sẳn sàng"-->
        <div class="meeting-info">
          <span class="name">
            <a href="#">{{item.roomName}}</a>
          </span>
          <div class="status pull-right">
            <span class="freetime" v-if="item.visible">
              <a href="#">
                <img src="/Content/Images/Ready.png" width="22" />
                Hiện
              </a>
            </span>
            <span class="freetime" v-else>
              <a href="#">
                <img src="/Content/Images/lock.png" width="22" />
                Tạm ẩn
              </a>
            </span>
          </div>
        </div>

        <!--Hiển thị hình đại diện của phòng họp-->
         <div class="meeting-image" v-if="item.roomAvatar">
          <img class="img-fluid" :src="item.roomAvatar" alt="Avatar" />
        </div>
        <div class="meeting-image" v-else>
          <img class="img-fluid" :src="nopic" alt="Avatar" />
        </div>
        <!--Hiển thị sức chứa của phòng-->
        <div class="capacity">
          <span href="#" title="">{{item.seat}} chỗ ngồi - {{item.videoCall?"có":"không"}} video Call - {{item.phoneCall?"có":"không"}} Phone</span>
        </div>

        <!--Hiển thị chi tiết-->
        <div class="descript">
          <router-link :to="{ name: 'book-detail', params: { id: item.roomID }}">{{item.roomName}}</router-link>
        </div>

        <!--Hiển thị 2 button "Đặt Phòng" và  "Chi tiết"-->
        <div class="lineaction">
          <div class="row">
            <div class="col-6">
              <a href="javascript:" class="btn btn-sm btn-warning detail-booking" @click="EditRoomDetail(item.roomID)">
                <i class="fa fa-edit" aria-hidden="true"></i>
                &nbsp;Chỉnh sửa
              </a>
            </div>
            <div class="col-6">
              <a href="javascript:" class="btn btn-sm btn-danger delete-booking" @click="DeleteRoom(item.roomID)">
                <i class="fa fa-trash-o" aria-hidden="true"></i>
                Xóa phòng
              </a>
              &nbsp;
            </div>
          </div>
        </div>

      </div>
    </div>

    <div class="col-12 alert alert-danger mt-2" role="alert" v-if="isNoneData">
      <strong>Thông báo!&nbsp;</strong>Không tìm thấy dữ liệu!
    </div>

    <!-- edit-room-component -->
    <admin-edit-room-component></admin-edit-room-component>
  </div>
</template>

<script>
  import AdminSearchRoomComponent from './AdminSearchRoomComponent.vue';
  import AdminEditRoomComponent from './AdminEditRoomComponent.vue';
  import axios from 'axios';
  import EventBus from '../EventBus';
  import { fail } from 'assert';
  import { debug } from 'util';
  export default {
    components: {
      AdminSearchRoomComponent,
      AdminEditRoomComponent
    },
    data() {
      return {
        isNoneData: false,
        isStatus: true,
        itemRoom: {},
        listRoom: [],
        nopic: "/Content/Images/ImageFound.png",
      }
    },
    methods: {
      SearchRoom(roomName, areaID) {
        axios.post('/Room/SearchAll', { roomName: roomName, areaID: areaID })
          .then(res => {
            this.listRoom = res.data;
            HideLoading();
          })
      },
      convertDate(date) {
        var nowDate = new Date(parseInt(date.substr(6)));
        return nowDate.format("dd/mm/yyyy");
      },
      convertTime(date) {
        var nowDate = new Date(parseInt(date.substr(6)));
        return nowDate.format("HH:MM");
      },

      showBooking: function (roomID) {
        if (this.$cookies.get('user')) {
          EventBus.$emit("showModalHome", roomID);
        }
        else {
          AlertDanger("Vui lòng đăng nhập để thực hiện chức năng này!");
          return false;
        }
      },
      DeleteRoom: function (roomID) {
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
          $.confirm({
            title: 'Cảnh báo!',
            content: 'Bạn có chắc chắn muốn xóa phòng này không ?',
            type: 'orange',
            typeAnimated: true,
            theme: "material",
            buttons: {
              Delete: {
                text: 'Xóa',
                btnClass: 'btn-red',
                action: function () {
                  axios.post("/Room/DeleteRoom", { roomID: roomID }).then(res => {
                    if (res.data.status == 1) {
                      EventBus.$emit("BindRoomHome", true);
                      AlertSuccess("Xin chúc mừng đã xóa dữ liệu thành công!");
                    }
                    else {
                      AlertWarning("Rất tiếc dữ liệu chưa được xóa, vui lòng kiểm tra lại!");
                    }
                  });
                }
              },
              close: function () {
              }
            }
          });
        }
      },
      EditRoomDetail: function (roomID) {
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
          axios.post("/Room/GetDetailRoom", { roomID: roomID }).then(res => {
            seft.itemRoom = res.data;
            EventBus.$emit("EditRom", seft.itemRoom);
          })
        }
      },
      addRoom: function () {
        if (this.$cookies.get('user') == null) {
          AlertWarning("Vui lòng đăng nhập để thực hiện chức năng này!");
          return false;
        }
        else if (!this.$cookies.get('user').Roles) {
          AlertWarning("Xin lỗi, bạn chưa được quyền thực hiện chức năng này!");
          return false;
        }
        else {
          $("#add-room").modal("show");
        }
      },
    },
    watch: {

    },
    created() {
      let seft = this;
      ShowLoading();
      EventBus.$on('BindSearchAdminRoom', (item) => {
        seft.listRoom = item;
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
