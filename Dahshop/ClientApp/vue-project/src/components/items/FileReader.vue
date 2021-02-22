<template>
  <section>
    <label for="files">Select multiple files</label>
    <input
      type="file"
      id="files"
      accept="image/jpg, image/jpeg, image/x-png"
      @change="setDataURL"
      multiple
    />
    <div class="justify-content-center">
      <div
        class="col-{breakpoint}-auto"
        v-for="(image, index) in imageList"
        :key="index"
      >
        <img
          class="imagePreview"
          id="imgs"
          :src="image"
          @load="revokeDataURL(index)"
        /> <br>
      </div>
    </div>
    <!-- <p v-else>No images selected</p> -->
  </section>
</template>

<script>
import useImagePreview from "../../hooks/imagePreview.js";

export default {
  setup() {
    const { imageList, setDataURL, revokeDataURL } = useImagePreview();

    return { imageList, setDataURL, revokeDataURL };
  },
};
</script>

<style scoped>
.imagePreview {
  height: 200px;
}
</style>
