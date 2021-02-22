export default {
    setItems(state, payload){
        state.items = payload;
    },
    addItem(state, payload) {
        state.items.unshift(payload);
    },
    setFiles(state, payload) {
        state.item.files = payload;
    },
    clearFiles(state) {
        // Clear the files
        state.item.files = [];
        console.log("Store state files set to empty!");
    }

};
