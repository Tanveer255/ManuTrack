/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.{razor,html,cshtml}", // Paths to Razor, HTML, and cshtml files
        "./node_modules/flowbite/**/*.js" // Include Flowbite components
    ],
    theme: {
        extend: {}, // Extend default TailwindCSS theme
    },
    plugins: [
        require('flowbite/plugin') // Correct way to include Flowbite plugin
        // Remove flowbite.plugin() or any extra references
    ],
};
