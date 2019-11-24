<template>
  <div>
    <!--nhúng Tìm kiếm  -->
    <search-home-component></search-home-component>
    <div class="card-columns listroom" v-if="listRoom.length>0">
      <div class="card meeting-group box-shadow" v-for="(item, index) in listRoom">
        <!--Hiển thị tên phòng và trạng thái "Sẳn sàng/Không sẳn sàng"-->
        <div class="meeting-info">
          <span class="name">
            <a href="#">{{item.roomName}}</a>
          </span>
          <div class="status pull-right">
            <span class="freetime" v-if="item.listLineRoom.length <= 0">
              <a href="#">
                <img src="/Content/Images/Ready.png" width="22" />
                Sẵn sàng
              </a>
            </span>
            <span class="freetime" v-else>
              <a href="#">
                <img src="/Content/Images/lock.png" width="22" />
                Đang bận
              </a>
            </span>
          </div>
        </div>

        <!--Hiển thị hình đại diện của phòng họp-->
        <div class="meeting-image" v-if="item.roomAvatar">
          <router-link tag="img" class="img-fluid" :src="item.roomAvatar" :to="{ name: 'book-detail', params: { id: item.roomID }}">User</router-link>
        </div>
        <div class="meeting-image" v-else>
          <router-link tag="img" class="img-fluid" :src="nopic" :to="{ name: 'book-detail', params: { id: item.roomID }}">User</router-link>
        </div>
        <!--Hiển thị sức chứa của phòng-->
        <div class="capacity">
          <span href="#" title="">{{item.seat}} Chỗ ngồi - {{item.videoCall?"Có":"Không"}} Video Call - {{item.phoneCall?"Có":"Không"}} Phone</span>
        </div>

        <!--Hiển thị chi tiết-->
        <div class="descript">
          <router-link :to="{ name: 'book-detail', params: { id: item.roomID }}">{{item.roomName}}</router-link>
        </div>

        <!--Hiển thị những khoảng thời gian đã đặt phòng-->

        <div class="sortline" v-if="item.listLineRoom.length>0">
          <span v-for="itemLine in item.listLineRoom">
            <a href="#" @click="showHomeDetail(itemLine.LineRoomID)">
              <p class="pline">
                <i class="fa fa-caret-square-o-right" aria-hidden="true"></i>&nbsp;
                {{convertTime(itemLine.TimeStart)}}-{{convertTime(itemLine.TimeEnd)}}({{convertDate(itemLine.TimeEnd)}})
              </p>
            </a>
          </span>
        </div>

        <!--Hiển thị 2 button "Đặt Phòng" và  "Chi tiết"-->
        <div class="lineaction">
          <div class="row">
            <div class="col-6">
              <a href="javascript:" class="btn btn-sm btn-success action-booking" @click="showBooking(item.roomID)">
                <i class="fa fa-plus-circle" aria-hidden="true"></i>
                Đặt phòng
              </a>
              &nbsp;
            </div>
            <div class="col-6">
              <router-link tag="a" class="btn btn-sm btn-info detail-booking" :to="{ name: 'book-detail', params: { id: item.roomID }}">   <i class="fa fa-newspaper-o" aria-hidden="true"></i> Chi tiết</router-link>
            </div>
          </div>
        </div>

      </div>
    </div>
    <div class="col-12 alert alert-danger mt-2" role="alert" v-if="isNoneData">
      <strong>Thông báo!&nbsp;</strong>Không tìm thấy dữ liệu!
    </div>
  </div>

</template>

<script>
  import SearchHomeComponent from './SearchHomeComponent.vue';
  import axios from 'axios';
  import EventBus from '../EventBus';
  import { fail } from 'assert';
  import { debug } from 'util';
  export default {
    components: {
      SearchHomeComponent,
    },
    data() {
      return {
        listRoom: [],
        isNoneData: false,
        isStatus: true,
        itemRoom: {},
        nopic: "/Content/Images/ImageFound.png",
      }
    },
    methods: {
      SearchRoom(roomName, areaID) {
        ShowLoading();
        axios.post('/Room/Search', { roomName: roomName, areaID: areaID })
          .then(res => {
            this.listRoom = res.data;
             HideLoading();
          }).catch(error => {
            AlertDanger("Lỗi hệ thống, vui lòng thử lại sau!");
            HideLoading();
            return false;
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
         if (this.user = this.$cookies.get('user')) {
           EventBus.$emit("showModalHome", roomID);
        }
        else {
           AlertWarning("Vui lòng đăng nhập để thực hiện chức năng này!");
          return false;
        }
      },
      showHomeDetail: function (LineRoomID) {
        axios.post("/LineRoom/GetDetailLineRoomByID", { LineRoomID: LineRoomID }).then(res => {
           let dataRoom = {room: res.data };
        EventBus.$emit("BookingDetail", dataRoom);
        })
      },
    },
    watch: {

    },
    created() {
      let seft = this;
      ShowLoading();
      EventBus.$on('DataBindRoom', (item) => {
        seft.listRoom = item;
        HideLoading();
        seft.isLoadingData = false;
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
