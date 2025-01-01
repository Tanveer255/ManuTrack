$(document).ready(function () {
    // Your code here
    console.log("Hello World!");
});
function getAllProduct() {
    // Define the API URL
    const apiUrl = 'https://localhost:7067/Product';

    // Make a GET request
    fetch(apiUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            debugger;
            console.log(data); // Handle the response data
        })
        .catch(error => {
            console.error('Error:', error); // Handle any errors
        });
}
//function saveProduct(product) {
//    const url = '/api/products/save'; // Replace with your actual API endpoint

//    fetch(url, {
//        method: 'POST',
//        headers: {
//            'Content-Type': 'application/json',
//        },
//        body: JSON.stringify(product),
//    })
//        .then(response => {
//            if (!response.ok) {
//                throw new Error(`HTTP error! Status: ${response.status}`);
//            }
//            return response.json();
//        })
//        .then(data => {
//            if (data.success) {
//                console.log('Product saved successfully:', data.message);
//                alert('Product saved successfully!');
//            } else {
//                console.error('Error saving product:', data.message);
//                alert('Error saving product: ' + data.message);
//            }
//        })
//        .catch(error => {
//            console.error('Error:', error);
//            alert('An unexpected error occurred: ' + error.message);
//        });
//}

//// Example usage
//const product = {
//    Title: "Sample Product",
//    BodyHtml: "<p>Description of the product</p>",
//    Vendor: "Sample Vendor",
//    ProductType: "Electronics",
//    Tags: "Sample,Product,Test",
//    Status: "Active",
//    ProductId: 1234567890, // Use an existing ID for update or a new one for create
//    Name: "Sample Product Name",
//    Description: "Detailed description of the product.",
//    SKU: "SKU12345",
//    UnitOfMeasure: "Piece",
//    UnitCost: 49.99,
//    StockLevel: 100,
//    ReorderLevel: 10,
//    LeadTimeInDays: 7,
//    Variants: [],
//    Options: [],
//    ImageFiles: [],
//};

//const variant = {
//    VariantId: "", // Generates a unique ID similar to the C# constructor
//    ParentProductId: null, // Assign the appropriate Parent Product ID
//    ProductId: null, // Assign the appropriate Product ID (if available)
//    Price: "19.99", // Example price
//    Position: 1, // Example position
//    InventoryPolicy: "continue", // Example inventory policy
//    CompareAtPrice: "24.99", // Example compare-at price
//    Option1: "Red", // Example option
//    Option2: "Large", // Example option
//    Option3: null, // Set if needed
//    Taxable: true, // Example taxable flag
//    Barcode: "123456789012", // Example barcode
//    FulfillmentService: "manual", // Example fulfillment service
//    Grams: 500, // Example weight in grams
//    InventoryManagement: "shopify", // Example inventory management
//    RequiresShipping: true, // Example shipping requirement
//    Sku: "SKU12345", // Example SKU
//    Weight: 0.5, // Example weight
//    WeightUnit: "kg", // Example weight unit
//    InventoryId: null, // Assign appropriate Inventory ID (if available)
//    InventoryQuantity: 100, // Example inventory quantity
//    OldInventoryQuantity: 90, // Example old inventory quantity
//    PresentmentPrices: [], // Array of PresentmentPrice objects, if applicable
//    ImageId: null, // Assign appropriate Image ID (if available)
//};
//function generateVariants(productId, options) {
//    const variants = [];

//    // Helper function to generate combinations of option values
//    function combineOptions(options, index, current) {
//        if (index === options.length) {
//            const variant = {
//                VariantId: Date.now() + variants.length, // Unique ID
//                ParentProductId: productId,
//                ProductId: productId,
//                Price: "0.00", // Default price, update as needed
//                Position: variants.length + 1,
//                InventoryPolicy: "deny", // Example policy
//                CompareAtPrice: null, // Optional
//                Option1: current[0] || null,
//                Option2: current[1] || null,
//                Option3: current[2] || null,
//                Taxable: true,
//                Barcode: null, // Optional
//                FulfillmentService: "manual",
//                Grams: 0, // Default weight
//                InventoryManagement: null,
//                RequiresShipping: true,
//                Sku: `SKU-${variants.length + 1}`, // Example SKU
//                Weight: 0,
//                WeightUnit: "kg", // Example unit
//                InventoryId: null,
//                InventoryQuantity: 0, // Default quantity
//                OldInventoryQuantity: 0,
//                PresentmentPrices: [], // Optional
//                ImageId: null,
//            };
//            variants.push(variant);
//            return;
//        }

//        for (let value of options[index].Values) {
//            combineOptions(options, index + 1, current.concat(value));
//        }
//    }

//    // Start generating combinations
//    combineOptions(options, 0, []);
//    return variants;
//}

//// Example usage
//const productId = "1234567890"; // Replace with the actual Product ID
//const options = [
//    {
//        Name: "Color",
//        Position: 1,
//        Values: ["Red", "Blue", "Green"],
//    },
//    {
//        Name: "Height",
//        Position: 2,
//        Values: ["Short", "Medium", "Tall"],
//    },
//    {
//        Name: "Width",
//        Position: 3,
//        Values: ["Narrow", "Wide"],
//    },
//];

//const variants = generateVariants(productId, options);
//console.log(variants);



