import { createStore } from 'vuex';

import itemsModule from './modules/items/index.js';

const store = createStore({
    modules: {
        items: itemsModule
    }
});

export default store;