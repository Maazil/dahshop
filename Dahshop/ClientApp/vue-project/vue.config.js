// vue.config.js file for setting the output directory to wwwroot in the main project
module.exports = {
  outputDir: "../../wwwroot/dist/",
  devServer: {
    proxy: {
      '^/api': {
        target: "https://localhost:5001",
        changeOrigin: true
      },
    }
  }
};
