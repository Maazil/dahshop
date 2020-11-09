// import { defineAsAsyncComponent } from 'vue';
import { createRouter, createWebHistory } from 'vue-router';

import ItemsList from './pages/items/ItemsList.vue';
import ItemRegistration from './pages/items/ItemRegistration.vue';
import NotFound from './pages/NotFound.vue';

const router = createRouter({
    history: createWebHistory(),
    routes: [
    { path: '/', component: ItemsList },
    // { path: '/user/:id', component: null },
    // { path: '/items/:id', component: null },
    { path: '/postitem', component: ItemRegistration },
    { path: '/:notFound(.*)', component: NotFound },

    ]
});

export default router;