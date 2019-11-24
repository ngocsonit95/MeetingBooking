
<template>
  <div class="row">
    <div class="col-6 mt-3">
      <!--Hiển thị hình đại diện của phòng họp-->
      <div class="seenimage">
        <img v-if="itemRoom.Avatar" :src="itemRoom.Avatar" class="img-fluid" />
        <img v-else :src="nopic" class="img-fluid" />
      </div>
    </div>
    <div class="col-6 mt-3">
      <div class="seeninfo">
        <!--Hiển thị dòng chữ "Thông tin chung"-->
        <div class="seentitle">
          <i class="fa fa-picture-o" aria-hidden="true"></i> Thông tin chung
        </div>
        <!--Hiển thị các thông tin về phòng hop như "phòng, khu vực, chổ ngồi, Video call, Phone Call"-->
        <div class="row">
          <div class="col-12 lines">
            <b>Tên phòng:&nbsp;</b><span>{{itemRoom.RoomName}}</span>
          </div>
          <div class="col-12 lines">
            <b>Khu vực:&nbsp;</b><span>{{itemRoom.AreaName}}</span>
          </div>
          <div class="col-12 lines">
            <b>Chỗ ngồi:&nbsp;</b><span>{{itemRoom.Seat}}</span>
          </div>
          <div class="col-12 lines">
            <b>Video call:&nbsp;</b><span>{{itemRoom.VideoCall?"Có":"Không"}}</span>
          </div>
          <div class="col-12 lines">
            <b>Phone call:&nbs p;</b><span>{{itemRoom.PhoneCall?"Có":"Không"}}</span>
          </div>
        </div>

      </div>
    </div>
    <!--<div class="mt-5 col-12" id='calendar'></div>-->
    <div class="mt-5 col-12">
      <FullCalendar locale="vi"
                    defaultView="dayGridMonth"
                    :header="calendarSeting.header"
                    :plugins="calendarSeting.calendarPlugins"
                    :events="data"
                    :eventLimit="4"
                    @eventRender="eventRender"
                    @dateClick="dateClick"
                    @eventClick="eventClick" />
    </div>
  </div>
</template>

<script>
  import axios from "axios";
  import FullCalendar from '@fullcalendar/vue'
  import dayGridPlugin from '@fullcalendar/daygrid'
  import timeGridPlugin from '@fullcalendar/timegrid'
  import interactionPlugin from '@fullcalendar/interaction'
  import viLocale from '@fullcalendar/core/locales/vi'
  import EventBus from "../EventBus";
  // Import this component
  import datePicker from 'vue-bootstrap-datetimepicker';
  export default {
    components: {
      FullCalendar,
    },
    data() {
      return {
        calendarSeting: {
          header: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay,listWeek'
          },
          calendarPlugins: [dayGridPlugin, timeGridPlugin, interactionPlugin],
        },
        itemRoom: {},
        data: [],
        user: {},
        isShow: false,
        nopic: "/Content/Images/ImageFound.png",
      }
    },
    methods: {
      LoadInfoRoom: function () {
        let seft = this;
        let roomID = this.$route.params.id;
        axios.post("/Room/GetDetailRoom", { roomID: roomID }).then(res => {
          seft.itemRoom = res.data;
        })
      },
      LoadTimeLine: function () {
        let seft = this;
        let roomID = this.$route.params.id;
        axios.post("/LineRoom/GetLineRoomByRoomID", { roomID: roomID }).then(res => {
          seft.data = res.data;
        })
      },
      eventRender: function (arg) {
        let tempTooltip = '<p><b class="title">Nội dung</b>: {0} </p><p><b class="title">Start</b>: {1}</p><p><b class="title">End</b>:  {2}</p>';
        tempTooltip = tempTooltip.replace("{0}", arg.event.title);
        tempTooltip = tempTooltip.replace("{1}", arg.event.start.format("HH:MM (dd/mm/yyyy)"));
        tempTooltip = tempTooltip.replace("{2}", arg.event.end.format("HH:MM (dd/mm/yyyy)"));

        $(arg.el).tooltipster({
          content: tempTooltip,
          contentAsHTML: true,
          animation: 'swing',
          theme: 'tooltipster-punk',

        });

      },
      dateClick: function (arg) {
        debugger;
        let seft = this;
        if (!seft.$cookies.isKey("user")) {
          AlertDanger("Vui lòng đăng nhập để thực hiện chức năng đặt phòng");
          return;
        }

        let d = new Date();
        let currentDate = d.format("yyyy-mm-dd");
        if (Compare(arg.dateStr, currentDate) == -1) {
          AlertDanger("Ngày bạn chọn không phù hợp với thời gian hiện tại! Xin vui lòng chọn ngày >= ngày hiện tại");
          return;
        }
        EventBus.$emit("calendarBooking", arg);
      },
      eventClick: function (arg) {
        let sendData = { arg: arg, room: this.itemRoom };
        EventBus.$emit("showDetail", sendData);
      },
    },
    mounted() {
    },
    updated() {

    },
    created() {
      let seft = this;
      seft.LoadInfoRoom();
      seft.LoadTimeLine();
      EventBus.$on("loadLineRoom", res => {
        seft.data = res;
      });

      //Khi chỉnh sửa room xong thì Binding để load lại data info room
      EventBus.$on("BindDataRoomDetail", item => {
        if (item) {
          seft.LoadInfoRoom();
        }
      });

      if (seft.user = seft.$cookies.get('user')) {
        seft.isShow = true;
      }
      else {
        seft.isShow = false;
      }
    }
  }
</script>

