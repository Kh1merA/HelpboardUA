window.onload = () => {
    const uploadFile = document.getElementById("upload-file");
    const uploadBtn = document.getElementById("downloadBtn");
    const uploadText = document.getElementById("upload-text");

    uploadBtn.addEventListener("click", function () {
        uploadFile.click();
    });

    uploadFile.addEventListener("change", function () {
        const fileName = uploadFile.value;
        const validExtensions = ["jpg", "jpeg", "png", "svg"];
        const fileExtension = fileName.split(".").pop().toLowerCase();

        if (!fileName) {

            uploadText.innerText = "Файл не обрано";
        } else if (validExtensions.includes(fileExtension)) {
            uploadText.innerText = fileName.match(/[\/\\]([\w\d\s\.\-(\)]+)$/)[1];
        } else {
            uploadFile.value = null;
            uploadText.innerText = "Файл має непідтримуваний формат";
        }
    });
}