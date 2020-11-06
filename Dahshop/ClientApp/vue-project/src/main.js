import { createApp, defineAsyncComponent } from 'vue';
import App from './App.vue';

import router from './router.js';
import store from './store/index.js';
import BaseCard from './components/ui/BaseCard.vue';
import BaseButton from './components/ui/BaseButton.vue';

// Async because its only downloaded when needed
const BaseDialog = defineAsyncComponent(() => import('./components/ui/BaseDialog.vue'));

// Create the app and use store, router and components then mount the app.
const app = createApp(App);

app.use(router);

app.use(store);

app.component('base-card', BaseCard);
app.component('base-button', BaseButton);
app.component('base-dialog', BaseDialog);


app.mount('#app');