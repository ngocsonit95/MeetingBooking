import Vue from 'vue';
import VueRouter from 'vue-router';
import VueSession from 'vue-session';
import VueCookies from 'vue-cookies';
import App from './App.vue';
import { routes } from './routers';

Vue.use(VueRouter);
Vue.use(VueSession);
Vue.use(VueCookies);
// set default config
VueCookies.config('7d');

// set global cookie
VueCookies.set('theme', 'default');
VueCookies.set('hover-time', '1s');
const router = new VueRouter(
  {
    routes
  }
);
new Vue({
  el: '#app',
  router,
  render: h => h(App)
});
