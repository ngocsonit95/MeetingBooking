<template>
  <div class="col-md-9 col-sm-12 col-12">
    <div class="row mb-2">
      <div class="mt-2 col-md-4 col-sm-6 col-6">
        <input type="text" class="form-control" placeholder="Tìm kiếm user" v-model="fullName" autocomplete="off" />
      </div>
      <Select2 v-model="facultyID" :options="listFaculty" @select="selectFaculty($event)" class="col-md-4 col-sm-6 col-6 mt-2" />
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
        listFaculty: [{ id: 0, text: "Tất cả khoa" }],
        fullName: '',
        facultyID: 0,
        listUser: [],
        listParams: {}
      }
    },
    methods: {
      getAllFaculty() {
        this.listFaculty = [{ id: 0, text: "Tất cả khoa" }];
        axios.get('/Faculty/GetAllFaculty')
          .then(res => {
            let data = res.data;
            for (let i = 0; i < data.length; i++) {
              let model = [];
              model['id'] = data[i].FacultyID;
              model['text'] = data[i].FacultyName;
              this.listFaculty.push(model);
            }
          })
      },
      SearchUser(fullName, facultyID) {
        axios.post('/User/SearchAll', { fullName: this.fullName, facultyID: this.facultyID })
          .then(res => {
            let data = res.data;
            EventBus.$emit('BindSearchAdminUser', data);
          })
      },
      selectFaculty({ id, text }) {
        this.facultyID = id;
        this.SearchUser(this.fullName, this.facultyID);
      }
    },
    watch: {
      fullName: function (val, oldVal) {
        let seft = this;
        seft.value = val;
        seft.oldValue = oldVal;
        seft.SearchUser(val, seft.facultyID);
      },
    },
    created() {
      let seft = this;
      seft.getAllFaculty();
      seft.SearchUser('', 0);
      //$on để lắng nghe sự kiện gì đó và thực thi
      EventBus.$on('BindUserHome', (item) => {
        if (item) {
          seft.SearchUser('', 0);
        }
      });
      EventBus.$on("BindFacultyHome", item => {
        if (item) {
          seft.getAllFaculty();
        }
      });
    }
  }
</script>
