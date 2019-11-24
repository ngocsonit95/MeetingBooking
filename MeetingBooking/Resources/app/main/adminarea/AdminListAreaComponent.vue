<template>
  <div>
    <div class="col-12 mt-2">
      <button class="btn btn-sm btn-primary pull-right" href="#" @click="addArea()">
        <i class="fa fa-plus"></i> Thêm khu vực
      </button>
    </div>
    <div class="clearfix"></div>
    <div class="card-columns listroom" v-if="listArea.length>0">
      <div class="card meeting-group box-shadow" v-for="(item, index) in listArea">
        <!--Hiển thị tên phòng và trạng thái "Sẳn sàng/Không sẳn sàng"-->
        <div class="meeting-info">
          <span class="name">
            <a href="#">{{item.AreaName}}</a>
          </span>
          <div class="status pull-right">
            <span class="freetime" v-if="item.Visible">
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
        <div class="meeting-image" v-if="item.Avatar">
          <img tag="img" class="img-fluid" :src="item.Avatar" alt="Avatar" />
        </div>
        <div class="meeting-image" v-else>
          <img class="img-fluid" :src="nopic" alt="Avatar" />
        </div>
        <!--Hiển thị sức chứa của phòng-->
        <div class="capacity">
          <span href="#" title="">{{item.Description}}</span>
        </div>

        <!--Hiển thị 2 button "Đặt Phòng" và  "Chi tiết"-->
        <div class="lineaction">
          <div class="row">
            <div class="col-6">
              <a href="javascript:" class="btn btn-sm btn-warning action-booking" @click="showAreaDetail(item.AreaID)">
                <i class="fa fa-edit" aria-hidden="true"></i>
                Chỉnh sửa
              </a>
            </div>
            <div class="col-6">
              <a href="javascript:" class="btn btn-sm btn-danger action-booking" @click="DeleteArea(item.AreaID)">
                <i class="fa fa-trash" aria-hidden="true"></i>
                Xóa
              </a>
            </div>
          </div>
        </div>

      </div>
    </div>

    <div class="col-12 alert alert-warning alert-dismissible fade show mt-2" role="alert" v-if="isNoneData">
      <strong>Thông báo!&nbsp;</strong>Không tìm thấy dữ liệu!
      <button type="button" class="close" data-dismiss="alert" aria-label="Close">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>

    <div class="col-12 alert alert-danger mt-2" role="alert" v-if="isNoneData">
      <strong>Thông báo!&nbsp;</strong>Không tìm thấy dữ liệu!
    </div>


    <!-- Add Area -->
    <admin-add-area-component></admin-add-area-component>

    <!-- Edit Area -->
    <admin-edit-area-component></admin-edit-area-component>
  </div>
</template>

<script>
  import AdminAddAreaComponent from './AdminAddAreaComponent.vue'
  import AdminEditAreaComponent from './AdminEditAreaComponent.vue'
  import axios from 'axios';
  import EventBus from "../EventBus";
  import { fileURLToPath } from "url";
  import { fail } from 'assert';
  import { debug } from 'util';
  export default {
    components: {
      AdminAddAreaComponent,
      AdminEditAreaComponent,
    },
    data() {
      return {
        listArea: {},
        itemArea: {},
        checkAccount: false,
        isNoneData: false,
        isStatus: true,
         nopic: "/Content/Images/ImageFound.png",
      }
    },
    methods: {
      showAreaDetail: function (AreaID) {
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
          axios.post("/ListArea/GetDetailArea", { AreaID: AreaID }).then(res => {
            seft.itemArea = res.data;
            EventBus.$emit("EditArea", seft.itemArea);
          });
        }
      },
      showArea: function () {
        ShowLoading();
        axios.get("/ListArea/GetAllArea/").then(res => {
          this.listArea = res.data;
          HideLoading();
        })
          .catch(error => {
            AlertDanger("Lỗi hệ thống, dữ liệu không tìm thấy, vui lòng thử lại sau!");
             HideLoading();
            return false;
          });
      },
      DeleteArea: function (AreaID) {
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
            content: 'Bạn có chắc chắn muốn khu vực này không ?',
            type: 'orange',
            typeAnimated: true,
            theme: "material",
            buttons: {
              Delete: {
                text: 'Xóa',
                btnClass: 'btn-red',
                action: function () {
                  axios.post("/ListArea/DeleteArea", { AreaID: AreaID }).then(res => {
                    if (res.data.status == 1) {
                      EventBus.$emit("BinArea", true);
                      AlertSuccess("Xin chúc mừng đã xóa dữ liệu thành công!");
                      $("#edit-area").modal("hide");
                    }
                    else {
                      AlertWarning("Rất tiếc dữ liệu chưa được xóa, vui lòng kiểm tra lại!");
                    }
                  }).catch(error => {
                    AlertDanger("Lỗi hệ thống, vui lòng thử lại sau!");
                    return;
                  });;
                }
              },
              close: function () {
              }
            }
          });
        }
      },
      addArea: function () {
        if (this.$cookies.get('user') == null) {
          AlertWarning("Vui lòng đăng nhập để thực hiện chức năng này!");
          return false;
        }
        else if (!this.$cookies.get('user').Roles) {
          AlertWarning("Xin lỗi, bạn chưa được quyền thực hiện chức năng này!");
          return false;
        }
        else {
          $("#add-area").modal("show");
        }
      },
    },
    watch: {

    },
    created() {
      let seft = this;
      seft.showArea();
      ShowLoading();
      EventBus.$on("BinArea", item => {
        seft.isLoadingData = false;
        seft.showArea();
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
