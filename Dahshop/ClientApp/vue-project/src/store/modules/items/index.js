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
                    ownerId: 'Matty',
                    name: 'Vintage Jacket',
                    color: 'Brown',
                    size: 'M',
                    location: 'Oslo',
                    price: 400,
                    description: 'New unused jacket',
                    filePath: ''
                },
                {
                    id: 2,
                    ownerId: 'Admin',
                    name: 'Ripped jeans',
                    color: 'Blue',
                    size: '164',
                    location: 'Kristiansand',
                    price: 340,
                    description: 'Used jeans in good state',
                    filePath: ''
                }
            ]
        };
    },
    mutations,
    actions,
    getters
};