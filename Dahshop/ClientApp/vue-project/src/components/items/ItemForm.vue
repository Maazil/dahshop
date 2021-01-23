<template>
  <div>
    <section>
      <file-reader></file-reader>
    </section>
    <section>
      <form @submit.prevent="submitForm">
        <div class="form-group" :class="{ invalid: !state.itemName.isValid }">
          <label for="itemname">Item name</label>
          <input
            type="text"
            class="form-control"
            id="itemname"
            v-model.trim="state.itemName.val"
            @blur="clearValidity('itemName')"
          />
          <p v-if="!state.itemName.isValid">Item name must not be empty</p>
        </div>

        <div class="form-group" :class="{ invalid: !state.itemColor.isValid }">
          <label for="itemcolor">Color</label>
          <input
            type="text"
            class="form-control"
            id="itemcolor"
            v-model.trim="state.itemColor.val"
            @blur="clearValidity('itemColor')"
          />
          <p v-if="!state.itemColor.isValid">Item color must not be empty</p>
        </div>

        <div class="form-group" :class="{ invalid: !state.itemSize.isValid }">
          <label for="itemsize">Size</label>
          <input
            type="text"
            class="form-control"
            id="itemsize"
            v-model.trim="state.itemSize.val"
            @blur="clearValidity('itemSize')"
          />
          <p v-if="!state.itemSize.isValid">Item size must not be empty</p>
        </div>

        <div
          class="form-group"
          :class="{ invalid: !state.itemLocation.isValid }"
        >
          <label for="itemlocation">Location</label>
          <input
            type="text"
            class="form-control"
            id="itemlocation"
            v-model.trim="state.itemLocation.val"
            @blur="clearValidity('itemLocation')"
          />
          <p v-if="!state.itemLocation.isValid">
            Item location must not be empty
          </p>
        </div>

        <div class="form-group" :class="{ invalid: !state.itemPrice.isValid }">
          <label for="itemprice">Price (NOK)</label>
          <input
            type="number"
            class="form-control"
            id="itemprice"
            v-model.trim="state.itemPrice.val"
            @blur="clearValidity('itemPrice')"
          />
          <p v-if="!state.itemPrice.isValid">Item price must not be empty</p>
        </div>

        <div
          class="form-group"
          :class="{ invalid: !state.itemDescription.isValid }"
        >
          <label for="itemdescription">Description (additional info)</label>
          <textarea
            placeholder="New? Used? If so, then how long?"
            class="form-control"
            id="itemdescription"
            rows="5"
            v-model.trim="state.itemDescription.val"
            @blur="clearValidity('itemDescription')"
          />
          <p v-if="!state.itemDescription.isValid">
            Item description must not be empty
          </p>
        </div>
        <p v-if="!state.formIsValid">Please fix the errors above</p>

        <base-button>Register item</base-button>
      </form>
    </section>
  </div>
</template>

<script>
import { reactive, computed, ref } from "vue";
import FileReader from "../items/FileReader.vue";
import { useStore } from "vuex";

export default {
  components: {
    FileReader,
  },

  setup() {
    // use store
    const store = useStore();

    // Store the files uploaded
    const images = ref([]);

    // store the item data
    const state = reactive({
      Id: 0,
      itemName: {
        val: "",
        isValid: true,
      },
      itemColor: {
        val: "",
        isValid: true,
      },
      itemSize: {
        val: "",
        isValid: true,
      },
      itemLocation: {
        val: "",
        isValid: true,
      },
      itemPrice: {
        val: "",
        isValid: true,
      },
      itemDescription: {
        val: "",
        isValid: true,
      },
      filePath: "",
      formIsValid: true,
    }); // state const

    function clearValidity(input) {
      return (state[input].isValid = true);
    }

    function validateForm() {
      // set formIsValid to true as default
      state.formIsValid = true;
      // check form validity and set state
      if (state.itemName.val === "") {
        state.itemName.isValid = false;
        state.formIsValid = false;
      }
      if (state.itemColor.val === "") {
        state.itemColor.isValid = false;
        state.formIsValid = false;
      }
      if (state.itemSize.val === "") {
        state.itemSize.isValid = false;
        state.formIsValid = false;
      }
      if (state.itemLocation.val === "") {
        state.itemLocation.isValid = false;
        state.formIsValid = false;
      }
      if (!state.itemPrice.val || state.itemPrice.val < 0) {
        state.itemPrice.isValid = false;
        state.formIsValid = false;
      }
      if (state.itemDescription.val === "") {
        state.itemDescription.isValid = false;
        state.formIsValid = false;
      }
    } // end of validate form function


    function getImages() {

      const allFiles = computed(function() {
        return store.getters["items/files"];
      });

      images.value = allFiles.value;
    }

    function submitForm() {
      // Validate the form first
      this.validateForm();

      // If the form is not valid return
      if (!state.formIsValid) return;

      getImages();

      // var FormData = require('form-data');
      var fdata = new FormData();

      const files = images.value;

      // console.log("List of images: " + files);

      for (var i = 0; i < files.length; i++) {
        let file = files[i];
        console.log(file);
        fdata.append("files", file);
      }

      fdata.append("name", state.itemName.val);
      fdata.append("color", state.itemColor.val);
      fdata.append("size", state.itemSize.val);
      fdata.append("location", state.itemLocation.val);
      fdata.append("price", state.itemPrice.val);
      fdata.append("description", state.itemDescription.val);
      // fdata.append("filePath", state.filePath);
      // clientToServer.addStructure(formData, self);

      // console.log(fdata);

      store.dispatch("items/postItem", fdata);

      console.log("Form has been submitted");
    } // end of submit form func

    return {
      state,
      images,
      clearValidity,
      validateForm,
      submitForm,
    };
  },
};
</script>

<style scoped>
.invalid label {
  color: red;
}

.invalid input,
.invalid textarea {
  border: 1px solid red;
}
</style>
