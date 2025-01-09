/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
      './src/**/*.{js,jsx,ts,tsx}', // Your component files
      './node_modules/flowbite/**/*.js' // Flowbite components
    ],
    theme: {
      extend: {},
    },
    plugins: [
      require('flowbite/plugin') // Add the Flowbite plugin here
    ],
  };
  