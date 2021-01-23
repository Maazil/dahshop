import mutations from './mutations.js';
import actions from './actions.js';
import getters from './getters.js';

// Dummy data for now
export default {
    namespaced: true,
    state(){
        return {
          items: [],
          item: {
            id: 0,
            name: "",
            color: "",
            size: "",
            location: "",
            price: 0,
            description: "",
            filePath: "",
            files: [] ,
          },
        };
    },
    mutations,
    actions,
    getters
};