<template>
  <section>
    <label for="files">Select multiple files</label>
    <input
      type="file"
      id="files"
      accept="image/*"
      @change="setDataURL"
      multiple
    />
    <div v-if="imageList.length > 0">
      <ul v-for="(image, index) in imageList" :key="index">
        <li>
          <!-- {{ index }} -->
          <img class="imagePreview" id="imgs" :src="imageList[index]" />
        </li>
      </ul>
    </div>
    <p v-else>List of images empty</p>
  </section>
</template>

<script>
// import { ref } from "vue";
export default {
  // store / expose data and functions
  setup() {
    // Image list store
    const imageList = [];

    function setDataURL(event) {
      // set image list to an empty array just in case
      this.imageList = [];

      // Reference to the DOM input elements
      const files = event.target.files;

      // Check file api support and if files is empty
      if (files && window.File && window.FileList && window.FileReader) {
        // Loop through the list of images uploaded
        for (let i = 0; i < files.length; i++) {
          // set file to files current index
          const file = files[i];

          console.log(file);

          // set the current index in imagelist to an object url
          this.imageList[i] = URL.createObjectURL(file);

        //   // Revoke the file to free memory
        //   URL.revokeObjectURL(this.imageList[i]);
        }
      }

      console.log(this.imageList);
    } // function Preview

    return { setDataURL, imageList };
  },
};
</script>

<style scoped>
.imagePreview {
  height: 200px;
}
</style>
