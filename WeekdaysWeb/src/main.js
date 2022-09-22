import Vue from 'vue';
import App from './App.vue';
import moment from 'moment';

Vue.config.productionTip = true;

Vue.filter('formatDate', function (value) {
    if (value) {
        moment.locale('en')
        return moment(String(value)).format("MM/DD/YYYY, hh:mm:ss a");
    }
});

new Vue({
    render: h => h(App)
}).$mount('#app');
