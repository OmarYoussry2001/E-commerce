var Upload = {
    UploadDefaultImg: function (e) {
        const files = e.target.files;
        let previewContainer = document.getElementById("tbImgSrc");
        previewContainer.innerHTML = "";

        if (files.length > 0) {
            Array.from(files).forEach(file => {
                let reader = new FileReader();
                reader.onload = function (event) {
                    let imgElement = document.createElement("img");
                    imgElement.className = "img-thumbnail";
                    imgElement.src = event.target.result;
                    imgElement.style.cssText = "width: 120px; height: 120px; border-radius: 10px; margin: 5px; object-fit: cover; border: 1px solid #ddd; padding: 5px;";
                    previewContainer.appendChild(imgElement);
                };
                reader.readAsDataURL(file);
            });
        }
    }
};
