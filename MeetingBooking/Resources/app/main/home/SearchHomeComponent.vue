<template>
  <div class="col-12 mt-2">
    <div class="row">
      <div class="col-md-3 col-sm-6 col-6 mt-2">
        <input type="text" class="form-control" placeholder="Tìm kiếm phòng" v-model="roomName" />
      </div>
      <div class="col-md-6 d-none d-md-block"></div>
      <Select2 v-model="areaID" :options="listArea" @select="selectArea($event)" class="col-md-3 col-sm-6 col-6 mt-2" />
    </div>
  </div>

</template>

<script>
  import axios from 'axios'
  import Select2 from 'v-select2-component';
  import EventBus from '../EventBus'
  export default {
    components: { Select2 },
    data() {
      return {
        listArea: [{ id: 0, text: "Tất cả khu vực" }],
        roomName: '',
        areaID: 0,
        listRoom: {},
        listParams: {}
      }
    },
    methods: {
      getAllArea() {
        this.listArea = [{ id: 0, text: "Tất cả khu vực" }];
        axios.get('/ListArea/GetListArea')
          .then(res => {
            let data = res.data;
            for (let i = 0; i < data.length; i++) {
              let model = [];
              model['id'] = data[i].AreaID;
              model['text'] = data[i].AreaName;
              this.listArea.push(model);
            }
          })
      },
      SearchRoom(roomName, areaID) {
        ShowLoading();
        axios.post('/Room/Search', { roomName: roomName, areaID: areaID })
          .then(res => {
            let data = res.data;
            HideLoading();
            EventBus.$emit('DataBindRoom', data);
          }).catch(error => {
            AlertDanger("Lỗi hệ thống, vui lòng thử lại sau");
          });
      },
      selectArea({ id, text }) {
        this.areaID = id;
        this.SearchRoom(this.roomName, this.areaID);
      }
    },
    watch: {
      roomName: function (val, oldVal) {
        debugger;
        this.value = val;
        this.oldValue = oldVal;
        this.getAllArea();
        this.SearchRoom(val, this.areaID);
      },
    },
    created() {
      let seft = this;
      seft.getAllArea();
      seft.SearchRoom('', 0);
      //$on để lắng nghe sự kiện gì đó và thực thi
      EventBus.$on("loadLineRoomHome", item => {
        //Nếu loadLineRoomHome trả về true thì thực hiện func SearchRoom
        if (item) {
          seft.SearchRoom(seft.roomName, seft.areaID);
        }
      });
      EventBus.$on('BindRoomHome', (item) => {
        if (item) {
           seft.SearchRoom('', 0);
        }
      });
      EventBus.$on("BindAreaHome", item => {
        if (item) {
          seft.getAllArea();
        }
      });
    }
  }
</script>
