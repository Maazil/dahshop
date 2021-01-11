<template>
  <div>
    <section>
      <file-reader></file-reader>
    </section>
    <section>
      <form @submit.prevent="submitForm">
        <div class="form-control" :class="{ invalid: !state.itemName.isValid }">
          <label for="itemname">Item name</label>
          <input
            type="text"
            id="itemname"
            v-model.trim="state.itemName.val"
            @blur="clearValidity('itemName')"
          />
          <p v-if="!state.itemName.isValid">Item name must not be empty</p>
        </div>

        <div
          class="form-control"
          :class="{ invalid: !state.itemColor.isValid }"
        >
          <label for="itemcolor">Color</label>
          <input
            type="text"
            id="itemcolor"
            v-model.trim="state.itemColor.val"
            @blur="clearValidity('itemColor')"
          />
          <p v-if="!state.itemColor.isValid">Item color must not be empty</p>
        </div>

        <div class="form-control" :class="{ invalid: !state.itemSize.isValid }">
          <label for="itemsize">Size</label>
          <input
            type="text"
            id="itemsize"
            v-model.trim="state.itemSize.val"
            @blur="clearValidity('itemSize')"
          />
          <p v-if="!state.itemSize.isValid">Item size must not be empty</p>
        </div>

        <div
          class="form-control"
          :class="{ invalid: !state.itemLocation.isValid }"
        >
          <label for="itemlocation">Location</label>
          <input
            type="text"
            id="itemlocation"
            v-model.trim="state.itemLocation.val"
            @blur="clearValidity('itemLocation')"
          />
          <p v-if="!state.itemLocation.isValid">
            Item location must not be empty
          </p>
        </div>

        <div
          class="form-control"
          :class="{ invalid: !state.itemPrice.isValid }"
        >
          <label for="itemprice">Price (NOK)</label>
          <input
            type="number"
            id="itemprice"
            v-model.trim="state.itemPrice.val"
            @blur="clearValidity('itemPrice')"
          />
          <p v-if="!state.itemPrice.isValid">Item price must not be empty</p>
        </div>

        <div
          class="form-control"
          :class="{ invalid: !state.itemDescription.isValid }"
        >
          <label for="itemdescription">Description (additional info)</label>
          <textarea
            placeholder="New? Used? If so, then how long?"
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
import { reactive } from "vue";
import FileReader from '../items/FileReader.vue';

export default {
  components:{
    FileReader
  },

  setup() {
    // store the data
    const state = reactive({
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
      itemFiles: {
        val: "",
        isValid: true,
      },
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

    function submitForm() {
      this.validateForm();

      if (!state.formIsValid) return;

      console.log("Form has been submitted");
    } // end of submit form func

    return { state, clearValidity, validateForm, submitForm };
  },
};
</script>

<style scoped>
.form-control {
  margin: 1rem 0;
}

label {
  font-weight: bold;
  display: block;
  margin-bottom: 0.5rem;
}

input[type="checkbox"] + label {
  font-weight: normal;
  display: inline;
  margin: 0 0 0 0.5rem;
}

input,
textarea {
  display: block;
  width: 100%;
  border: 1px solid #ccc;
  font: inherit;
}

input:focus,
textarea:focus {
  background-color: #f0e6fd;
  outline: none;
  border-color: #3d008d;
}

input[type="checkbox"] {
  display: inline;
  width: auto;
  border: none;
}

input[type="checkbox"]:focus {
  outline: #3d008d solid 1px;
}

h3 {
  margin: 0.5rem 0;
  font-size: 1rem;
}

.invalid label {
  color: red;
}

.invalid input,
.invalid textarea {
  border: 1px solid red;
}
</style>
