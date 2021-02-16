<template>
    <div>
        <li>
          <div class="text-center">

            <h3>{{ name }}</h3>

            <div class="container">
              <div class="row justify-content-md-center">
                <div class="col-md-auto ratio ratio-4x5">
                  <img :src="setSelectedImage(selectedIndex)" width="300" height="375">
                </div>
              </div>

              <ul v-if="imageList.length > 1" class="row justify-content-md-center">
                <div class="col-{breakpoint}-auto" v-for="(image, indx) in imageList" :key="indx">
                  <button class="ratio ratio-4x5" @click="chooseImage(indx)">
                    <img :src="image" alt="thumbnail" width="40" height="50">
                  </button>
                </div>
              </ul>

            </div>

            <p>Color: {{ color }}</p>
            <p>Size: {{ size }}</p>
            <p>Location: {{ location }}</p>
            <h4>Price: {{ price }} kr</h4>
            <p> Description: {{ description }}</p>
            <div>
                <base-button mode="outline">View details</base-button>
            </div>

          </div>
            
        </li>
    </div>
</template>

<script>

import {ref} from 'vue';

export default {
    props: ['id', 'name', 'color', 'size', 'price', 'location', 'description', "filePath"],
    setup(props){
      
      // Split the filepaths into an array of image files
      const splitFilepath = props.filePath.split(',');
      console.log(splitFilepath);

      // Store the array 
      const imageList = ref(splitFilepath);

      console.log(imageList.value.length);

      // Variable to store selected index of array
      const selectedIndex = ref(0);

      // Variable to use as source for the selected image
      const img_src = ref("");

      // Choose the image based on index
      function chooseImage(index){
          selectedIndex.value = index;
      }

      // Set the image file based on index
      function setSelectedImage(index){
        console.log("Selected image file " + imageList.value[index]);
        return imageList.value[index];
      }

      // const getImage = computed(function() {
      //    return img_src.value;
      // });

      return { imageList, img_src, selectedIndex, chooseImage, setSelectedImage }

    }
}
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
</style>
