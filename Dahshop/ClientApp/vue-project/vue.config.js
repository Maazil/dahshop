// vue.config.js file for setting the output directory to wwwroot in the main project
 module.exports = {
   outputDir: '../../wwwroot/dist/',
    devServer: {
      proxy: 'https://localhost:5001'
    },
 }