//Define router to component

import HomeComponent from './home/HomeComponent.vue';
import HomeBookDetailComponent from './bookdetail/HomeBookDetailComponent.vue';
import AdminListAreaComponent from './adminarea/AdminListAreaComponent.vue';
import AdminListRoomComponent from './adminroom/AdminListRoomComponent.vue';
import AdminListUserComponent from './adminuser/AdminListUserComponent.vue';
import AdminListFacultyComponent from './adminfaculty/AdminListFacultyComponent.vue';
import ReportComponent from './report/ReportComponent.vue';

export const routes = [
  {
    path: '/',
    name: 'Home',
    meta: { title: 'Trang chủ' },
    component: HomeComponent
  },

  {
    path: '/book-detail/:id',
    name: 'book-detail',
    meta: { title: 'Chi tiết phòng' },
    component: HomeBookDetailComponent
  },

  {
    path: '/list-area',
    name: 'list-area',
    meta: { title: 'Danh sách khu vực' },
    component: AdminListAreaComponent
  },

  {
    path: '/list-area/:id',
    name: 'list-area',
    meta: { title: 'Danh sách khu vực' },
    component: AdminListAreaComponent
  },

   {
    path: '/list-room',
     name: 'list-room',
    meta: { title: 'Danh sách phòng' },
     component: AdminListRoomComponent
   },

  {
    path: '/list-faculty',
    name: 'list-faculty',
    meta: { title: 'Danh sách khoa' },
    component: AdminListFacultyComponent
  },

    {
    path: '/list-user',
      name: 'list-user',
    meta: { title: 'Danh sách người dùng' },
      component: AdminListUserComponent
  },

  {
    path: '/report',
    name: 'report',
    meta: { title: 'Thống kê' },
    component: ReportComponent
  },

  {
    path: "*",
    component: HomeComponent,
    meta: { title: '404 Page! Không tìm thấy trang' },
  }
];
