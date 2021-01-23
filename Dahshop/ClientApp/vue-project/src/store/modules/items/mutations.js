export default {
    setItems(state, payload){
        state.items = payload;
    },
    addItem(state, payload) {
        state.items.push(payload);
    },
    setFiles(state, payload) {
        state.item.files = payload;
    },

};
