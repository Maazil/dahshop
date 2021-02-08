import axios from "axios";

export default {
  getItems(context) {
    try {
      axios.get("api/server/items").then(function(response) {
        context.commit("setItems", response.data.reverse());
        console.log("Response: " + JSON.stringify(response.data));
      });
    } catch (error) {
      //   const error = new Error(responseData.message || "Failed to fetch!");
      //   throw error;
      console.log(error);
    }
  },

  postItem(context, formdata) {
    try {
      axios
        .post("api/server/items", formdata, {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        })
        .then(function (response) {
          context.commit("addItem", response.data);
          console.log("Item successfully posted to database");
        });
    } catch (error) {
      console.log(error);
    }
  },

  setFiles(context, data) {
    try {
      context.commit("setFiles", data);
    } catch (error) {
      console.log(error);
    }
  },


};
