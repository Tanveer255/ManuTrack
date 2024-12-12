// wwwroot/js/app.js

// Import the necessary Flowbite styles
import 'flowbite';
import 'flowbite/dist/flowbite.min.css';

// Import only the components you need from Flowbite
import { Tooltip, Popover } from 'flowbite';

// Initialize Flowbite components
document.querySelectorAll('[data-tooltip-target]').forEach((element) => {
    new Tooltip(element);
});

document.querySelectorAll('[data-popover-target]').forEach((element) => {
    new Popover(element);
});
