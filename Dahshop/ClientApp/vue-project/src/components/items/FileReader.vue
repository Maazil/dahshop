<template>
  <section>
    <label for="file">
      <img class="imagePreview" id="img" :src="imageData" />
    </label>
    <input type="file" id="file" accept="image/*" @change="setDataURL" />
  </section>
</template>

<script>
import { ref } from "vue";
export default {
  setup() {
    // Data store for the image
    const imageData = ref("");

    function setDataURL(event) {
      // Reference to the DOM input element
      var input = event.target;

      if (input.files && input.files[0]) {
        // create a new FileReader to read this image and convert to base64 format
        var reader = new FileReader();
        // Define a callback function to run, when FileReader finishes its job
        reader.onload = (e) => {
          // Note: arrow function used here, so that "this.imageData" refers to the imageData of Vue component
          // Read image as base64 and set to imageData
          this.imageData = e.target.result;
        };
        // Start the reader job - read file as a data url (base64 format)
        reader.readAsDataURL(input.files[0]);
      }

      //   // Get images and preview
      //   const reader = new FileReader();
      //   // const fileInput = document.getElementById("file");
      //   const img = document.getElementById("img");
      //   reader.onload = (event) => {
      //     img.src = event.target.result;
      //   };

      //   const f = event.target.files[0];
      //   reader.readAsDataURL(f);

      //   //   fileInput.addEventListener("change", (event) => {
      //   //     const f = event.target.files[0];
      //   //     reader.readAsDataURL(f);
      //   //   });
    }

    return { setDataURL, imageData };
  },
};
</script>

<style scoped>

.imagePreview {
    height: 200px;
}



</style>