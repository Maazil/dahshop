import mutations from './mutations.js';
import actions from './actions.js';
import getters from './getters.js';

// Dummy data for now
export default {
    namespaced: true,
    state(){
        return {
            items: [
                {
                    id: 1,
                    name: 'Vintage Jacket',
                    color: 'Brown',
                    size: 'M',
                    price: 400,
                    location: 'Oslo',
                    description: 'New unused jacket'
                },
                {
                    id: 2,
                    name: 'Ripped jeans',
                    color: 'Blue',
                    size: '164',
                    price: 340,
                    location: 'Kristiansand',
                    description: 'Used jeans in good state'
                }
            ]
        };
    },
    mutations,
    actions,
    getters
};