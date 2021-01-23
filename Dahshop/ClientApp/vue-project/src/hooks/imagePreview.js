import { ref } from "vue";
import { useStore } from "vuex";

export default function useImagePreview() {
  const store = useStore();

  // One to use for preview in browser
  // One to store the image files to send as formdata
  const imageList = ref([]);

  function setDataURL(event) {

    let imageListToSendToState = [];

    // set image list to an empty array just in case
    imageList.value = [];

    // Reference to the DOM input elements
    const files = event.target.files;

    // Check file api support and if files is empty
    if (files && window.File && window.FileList && window.FileReader) {
      // Loop through the list of images uploaded
      for (let i = 0; i < files.length; i++) {
        // set file to files current index
        const file = files[i];

        // console.log(file);

        imageListToSendToState.push(file);

        // set the current index in imagelist to an object url
        imageList.value.push(URL.createObjectURL(file));
      }
    }

    console.log(imageListToSendToState);

    // Add image files to store
    store.dispatch("items/setFiles", imageListToSendToState);
  }

  function revokeDataURL(index) {
    // Revoke the file to free memory
    URL.revokeObjectURL(imageList.value[index]);
  }

  return { imageList, setDataURL, revokeDataURL };
}
