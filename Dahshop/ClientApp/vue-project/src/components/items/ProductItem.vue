<template>
  <div>
    <li>
      <div class="text-center">
        <h3>{{ name }}</h3>

        <div class="container">
          <div class="row justify-content-md-center">
            <div class="col-md-auto ratio ratio-4x5">
              <img
                :src="setSelectedImage(selectedIndex)"
                width="300"
                height="375"
              />
            </div>
          </div>

          <div v-if="imageList.length > 1" class="row justify-content-center">
            <div
              class="col-{breakpoint}-auto"
              v-for="(image, indx) in imageList"
              :key="indx"
            >
              <button class="ratio ratio-4x5" @click="chooseImage(indx)">
                <img :src="image" alt="thumbnail" width="40" height="50" />
              </button>
            </div>
          </div>
        </div>

        <transition name="fade-button" mode="out-in">
          <div class="container" v-if="detailsAreVisible">
            <p>Color: {{ color }}</p>
            <p>Size: {{ size }}</p>
            <p>Location: {{ location }}</p>
            <h4>Price: {{ price }} kr</h4>
            <p>Description: {{ description }}</p>
          </div>
        </transition>
        <div>
          <transition name="fade-button" mode="out-in">
            <base-button @click="showDetails" v-if="!detailsAreVisible">View details</base-button>
            <base-button @click="hideDetails" v-else>Hide details</base-button>
          </transition>
        </div>
      </div>
    </li>
  </div>
</template>

<script>
import { ref } from "vue";

export default {
  props: [
    "id",
    "name",
    "color",
    "size",
    "price",
    "location",
    "description",
    "filePath",
  ],
  setup(props) {
    // Split the filepaths into an array of image files
    const splitFilepath = props.filePath.split(",");

    // Store the array
    const imageList = ref(splitFilepath);

    // Variable to store selected index of array
    const selectedIndex = ref(0);

    // Variable to use as source for the selected image
    const img_src = ref("");

    // Choose the image based on index
    function chooseImage(index) {
      selectedIndex.value = index;
    }

    // Set the image file based on index
    function setSelectedImage(index) {
      return imageList.value[index];
    }

    // Data for checking if details button is clicked
    const detailsAreVisible = ref(false);

    // Toggle details button between visible and hidden
    // Set the visibility to the opposite of the current state
    function showDetails() {
      detailsAreVisible.value = true;
    }

    function hideDetails() {
      detailsAreVisible.value = false;
    }

    return {
      imageList,
      img_src,
      selectedIndex,
      chooseImage,
      setSelectedImage,
      detailsAreVisible,
      showDetails,
      hideDetails
    };
  },
};
</script>

<style scoped>
li {
  margin: 1rem 0;
  border: 1px solid #424242;
  border-radius: 12px;
  padding: 1rem;
}

h3 {
  font-size: 1.5rem;
}

h3,
h4 {
  margin: 0.5rem 0;
}

div {
  margin: 0.5rem 0;
}

.actions {
  display: flex;
  justify-content: flex-end;
}

img {
  max-width: 100%;
  height: auto;
}

.v-leave-to,
.v-enter-from {
  opacity: 0;
  transform: translateY(20px);
}

.v-leave-active, 
.v-enter-active {
  transition: all 0.3s ease-out;
}

.v-leave-from,
.v-enter-to {
  opacity: 1;
  transform: translateY(0);
}


.fade-button-enter-from,
.fade-button-leave-to {
  opacity: 0;
}

.fade-button-enter-active {
  transition: opacity 0.2s ease-out;
}

.fade-button-leave-active{
  transition: opacity 0.3s ease-in;
}

.fade-button-enter-to,
.fade-button-leave-from {
  opacity: 1;
}



</style>
