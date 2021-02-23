<template>
  <div>
    <section>Filter</section>
    <section>
      <base-card>
        <div class="controls">
          <base-button mode="outline" @click.prevent="refreshItems">Refresh</base-button>
        </div>
        <ul v-if="hasItems">
          <product-item
            v-for="item in allItems"
            :key="item.id"
            :id="item.id"
            :name="item.name"
            :size="item.size"
            :color="item.color"
            :location="item.location"
            :price="item.price"
            :description="item.description"
            :filePath="item.filePath"
          ></product-item>
        </ul>
        <h3 v-else>No items found</h3>
      </base-card>
    </section>
  </div>
</template>

<script>
import { useStore } from "vuex";
import { computed } from "vue";
import ProductItem from "../../components/items/ProductItem.vue";

export default {
  components: {
    ProductItem,
  },

  setup() {
    // set store as constant and then use it
    const store = useStore();

    // Send get request for all items
    store.dispatch("items/getItems");

    // store all items
    const allItems = computed(function() {
      return store.getters["items/items"];
    });

    // check if state has items
    const hasItems = computed(function() {
      return store.getters["items/hasItems"];
    });

    function refreshItems() {
      return store.dispatch("items/getItems") && console.log('All new items gotten');
    }

    // expose the variables to the template
    return { allItems, hasItems, refreshItems };
  },
};
</script>

<style scoped>
ul {
  list-style: none;
  margin: 0;
  padding: 0;
}

.controls {
  display: flex;
  justify-content: center;
}
</style>
