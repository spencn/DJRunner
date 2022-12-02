// JavaScript source code
mergeInto(LibraryManager.library, {
  musicUploaderCaptureClick: function() {
    if (!document.getElementById('MusicUploaderInput')) {
      var fileInput = document.createElement('input');
      fileInput.setAttribute('type', 'file');
      fileInput.setAttribute('id', 'MusicUploaderInput');
      fileInput.style.visibility = 'hidden';
      fileInput.onclick = function (event) {
        this.value = null;
      };
      fileInput.onchange = function (event) {
        SendMessage('upload_menu', 'FileSelected', URL.createObjectURL(event.target.files[0]));
      }
      document.body.appendChild(fileInput);
    }
    var OpenFileDialog = function() {
      document.getElementById('MusicUploaderInput').click();
      document.getElementById('#canvas').removeEventListener('click', OpenFileDialog);
    };
    document.getElementById('#canvas').addEventListener('click', OpenFileDialog, false);
  }
});
