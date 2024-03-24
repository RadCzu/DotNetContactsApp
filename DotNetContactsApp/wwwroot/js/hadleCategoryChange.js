function handleCategoryChange() {
    // Dynamicly changing input field based on selected category
    const category = document.getElementById("contactCategory").value;
    const subcategoryBuisnessField = document.getElementById("subcategory-buisness-field");
    const otherSubcategoryField = document.getElementById("subcategory-other-field");

    if (category === "Buisness") {
        subcategoryBuisnessField.style.display = "block";
        otherSubcategoryField.style.display = "none";
    } else if (category === "Other") {
        subcategoryBuisnessField.style.display = "none";
        otherSubcategoryField.style.display = "block";
    } else if (category === "Private") {
        subcategoryBuisnessField.style.display = "none";
        otherSubcategoryField.style.display = "none";
    } else {
        subcategoryBuisnessField.style.display = "none";
        otherSubcategoryField.style.display = "none";
    }

    // Reset selected value to the first option
    document.getElementById("subcategory-select").selectedIndex = 0;
}