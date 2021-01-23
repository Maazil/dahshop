export default {
  items(state) {
    return state.items;
  },
  hasItems(state) {
    return state.items && state.items.length > 0;
  },
  files(state) {
    return state.item.files;
  },
};
