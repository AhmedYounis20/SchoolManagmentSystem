function downloadPic(fileContentURL, filename) {
        var link = window.document.createElement('a');
    link.href = fileContentURL;
        link.download = filename;

        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
}