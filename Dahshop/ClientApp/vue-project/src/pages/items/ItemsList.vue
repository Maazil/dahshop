<template>
  <div>
    <section>Filter</section>
    <section>
      <base-card>
        <div class="controls">
          <base-button mode="outline">Refresh</base-button>
          <base-button link to="/">Register as user</base-button>
        </div>
        <ul v-if="hasItems">
          <product-item
            v-for="item in filteredItems"
            :key="item.id"
            :id="item.id"
            :name="item.name"
            :size="item.size"
            :location="item.location"
            :price="item.price"
            :description="item.description"
          ></product-item>
        </ul>
        <h3 v-else>No items found</h3>
      </base-card>
    </section>
  </div>
</template>

<script>
import ProductItem from "../../components/items/ProductItem.vue";

export default {
  components: {
    ProductItem,
  },
  data() {
    return {
      isLoading: false,
      error: null,
    };
  },
  computed: {
    filteredItems() {
      return this.$store.getters["items/items"];
    },
    hasItems() {
      return !this.isLoading && this.$store.getters["items/hasItems"];
    },
  },
  created() {
    // this.loadCoaches();
  },
  methods: {
    // async loadCoaches(refresh = false) {
    //   this.isLoading = true;
    //   try {
    //     await this.$store.dispatch("coaches/loadCoaches", {
    //       forceRefresh: refresh,
    //     });
    //   } catch (error) {
    //     this.error = error.message || "Something went wrong";
    //   }
    //   this.isLoading = false;
    // },
    handleError() {
      this.error = null;
    },
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
  justify-content: space-between;
}
</style>
