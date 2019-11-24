D
<template>
  <div id="detailBooking" class="modal fade in" role="dialog">
    <div class="modal-dialog">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header title-booking">
          <span class="modal-title">
            <i class="fa fa-user-circle"></i>
            {{title}}
          </span>
          <button type="button" class="close" data-dismiss="modal">×</button>
        </div>
        <div class="modal-body">
          <div class="row">
            <div class="col-12 mageplus">
              <img v-if="room.Avatar" class="img-fluid" v-bind:src="room.Avatar" />
              <img v-else class="img-fluid" :src="nopic" />
            </div>
            <div class="box-content">
              <div class="col-12 time">
                <span><i class="fa fa-clock-o"></i>&nbsp;Thời gian:</span>
                <span class="timeline">
                  {{time}}
                </span>
              </div>

              <div class="col-12 memberinfo">
                <span><i class="fa fa-user"></i>&nbsp;Người book:</span>
                <span>{{fullName}}</span>
              </div>
              <div class="col-12 amount">
                <span><i class="fa fa-contao"></i>&nbsp;Số người tham dự:</span>
                <span>{{seat}}</span>
              </div>

              <div class="col-12 content">
                <span><i class="fa fa-newspaper-o"></i>&nbsp;Nội dung:</span>
                <span>
                  {{content}}
                </span>
              </div>
              <div class="col-12 device">
                <span><i class="fa fa-warning"></i>&nbsp;Ghi chú:</span>
                <span>
                  {{note}}
                </span>
              </div>
            </div>

          </div>
          <div class="text-center" v-if="isShow">
            <button class="btn btn-sm btn-warning" @click="EditBooking()">
              <i class="fa fa-edit"></i> Chỉnh sửa
            </button>
            <button class="btn btn-sm btn-danger" @click="DeleteBooking()">
              <i class="fa fa-trash"></i> Xóa
            </button>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>

<script>
  import axios from "axios";
  import EventBus from "../EventBus";
  import { fileURLToPath } from "url";
  export default {
    data() {
      return {
        room: {},
        idLineRoom: 0,
        title: "",
        time: "",
        seat: 0,
        createBy: "",
        fullName: "",
        Avatar: "",
        content: "",
        note: "",
        user: {},
        isShow: false,
        nopic: "/Content/Images/ImageFound.png",
      }
    },
    methods: {
      convertDate(date) {
        var nowDate = new Date(parseInt(date.substr(6)));
        return nowDate.format("dd/mm/yyyy");
      },
      convertTime(date) {
        var nowDate = new Date(parseInt(date.substr(6)));

        return nowDate.format("HH:MM");
      },
      DeleteBooking() {
        let seft = this;
        let data = { lineRoomID: seft.idLineRoom, roomID: seft.room.RoomID };
        $.confirm({
          title: 'Cảnh báo!',
          content: 'Bạn có chắc chắn muốn xóa lịch đặt phòng này không',
          type: 'orange',
          typeAnimated: true,
          theme: "material",
          buttons: {
            Delete: {
              text: 'Xóa',
              btnClass: 'btn-red',
              action: function () {
                axios.post("/LineRoom/DeleteLineRoomByID", data).then(res => {
                  if (res.data.isDelete == true) {
                    EventBus.$emit("loadLineRoom", res.data.result);
                    EventBus.$emit("loadLineRoomHome", res.data.result);
                    AlertSuccess(res.data.message);
                    $("#detailBooking").modal("hide");
                  }
                  else {
                    AlertDanger(res.data.message);
                    $("#detailBooking").modal("hide");
                  }
                });
              }
            },
            close: function () {
            }
          }
        });
      },
      EditBooking: function () {
        let seft = this;
        $("#detailBooking").modal("hide");
        axios.post("/LineRoom/EditLineRoomByID", { LineRoomID: seft.idLineRoom }).then(res => {
          if (res.data.isEdit == false) {
            AlertDanger(res.data.message);
          }
          else {
            let dataRoom = { room: res.data };
          EventBus.$emit("EditBooking", dataRoom);
          }
        })
      }
    },
    created() {
      let seft = this;
      seft.user = this.$cookies.get('user');

      EventBus.$on("showDetail", item => {
        seft.room = item.room;
        seft.title = item.arg.event.title;
        seft.time = item.arg.event.start.format("HH:MM (dd/mm/yyyy)") + " - " + item.arg.event.end.format("HH:MM (dd/mm/yyyy)");

        axios.post("/LineRoom/GetDetailLineRoomByID", { lineRoomID: item.arg.event.id }).then(res => {
          seft.idLineRoom = item.arg.event.id;
          seft.fullName = res.data.FullName;
          seft.seat = res.data.NumberPerson;
          seft.content = res.data.Content;
          seft.note = res.data.Description;
          seft.createBy = res.data.CreateBy;

          if (seft.$cookies.isKey('user')) {
            if (seft.$cookies.get('user').UserID == res.data.CreateBy) {
              seft.isShow = true;
            }
            else {
              seft.isShow = false;
            }
          }
          $("#detailBooking").modal("show");
        });

      });

      EventBus.$on("BookingDetail", item => {
        seft.user = seft.$cookies.get('user');

        seft.room = item.room;
        seft.title = item.room.LineRoomName;
        seft.time = "(" + seft.convertTime(item.room.TimeStart) + ")" + seft.convertDate(item.room.TimeStart) + " - " + "(" + seft.convertTime(item.room.TimeEnd) + ")" + seft.convertDate(item.room.TimeEnd);
        seft.idLineRoom = item.room.LineRoomID;
        seft.fullName = item.room.FullName;
        seft.seat = item.room.NumberPerson;
        seft.content = item.room.Content;
        seft.note = item.room.Description;
        seft.createBy = item.room.CreateBy;
        seft.Avatar = item.room.Avatar;

        if (seft.user = seft.$cookies.get('user')) {
          seft.isShow = true;
        }
        else {
          seft.isShow = false;
        }
        $("#detailBooking").modal("show");
      });
    }
  }
</script>
