function initializeImageUpload(uploadTriggerId, fileInputId, imagePreviewId, imagePreviewIconContainerId, imagePreviewIconId) {
    const uploadTrigger = document.getElementById(uploadTriggerId);
    const fileInput = document.getElementById(fileInputId);
    const imagePreview = document.getElementById(imagePreviewId);
    const imagePreviewIconContainer = document.getElementById(imagePreviewIconContainerId);
    const imagePreviewIcon = document.getElementById(imagePreviewIconId);

    uploadTrigger.addEventListener('click', () => {
        fileInput.click();
    });

    fileInput.addEventListener('change', (e) => {
        const file = e.target.files[0];
        
        if (file && file.type.startsWith('image/')) {
            const reader = new FileReader();
            
            reader.onload = (event) => {
                imagePreview.src = event.target.result;
                imagePreview.classList.remove('hide');
                imagePreviewIconContainer.classList.add('selected');
                imagePreviewIcon.classList.remove('fa-camera');
                imagePreviewIcon.classList.add('fa-pen-square');
                uploadTrigger.classList.remove('hide');
            };
            
            reader.onerror = () => {
                console.error('Error reading image file');
            };
            
            reader.readAsDataURL(file);
        } else if (file) {
            console.warn('Selected file is not an image');
            // Optional: Show error message to user
        }
    });
}

// Initialize the image upload for your project form
document.addEventListener('DOMContentLoaded', () => {
    initializeImageUpload('upload-trigger', 'image-upload', 'image-preview', 'image-preview-icon-container', 'image-preview-icon');
    
    // You can initialize multiple image uploads by calling this function with different IDs
    // initializeImageUpload('another-upload-trigger', 'another-image-upload', 'another-image-preview');
});
document.addEventListener('DOMContentLoaded', () => {
    const dropdownButtons = document.querySelectorAll('[data-type="dropdown"]');

    dropdownButtons.forEach(button => {
        button.addEventListener('click', (e) => {
            e.stopPropagation();
            const targetSelector = button.getAttribute('data-target') + '-dropdown';
            const targetDropdown = document.querySelector(targetSelector);

            // Close all other dropdowns
            document.querySelectorAll('.dropdown').forEach(dropdown => {
                if (dropdown !== targetDropdown) {
                    dropdown.classList.add('hide');
                }
            });

            // Toggle current dropdown
            targetDropdown.classList.toggle('hide');
        });
    });

    // Close dropdowns when clicking outside
    document.addEventListener('click', () => {
        document.querySelectorAll('.dropdown').forEach(dropdown => {
            dropdown.classList.add('hide');
        });
    });
});


const modals = document.querySelectorAll('[data-type="modal"]');
modals.forEach((modal) => {
    modal.addEventListener('click', (e) => {
        const targetId = modal.getAttribute('data-target');
        const targetModal = document.querySelector(targetId);
        targetModal.classList.add('modal-show');
    })
});

const closeButtons = document.querySelectorAll('[data-type="close"]');
closeButtons.forEach((button) => {
    button.addEventListener('click', (e) => {
        const targetId = button.getAttribute('data-target');
        const targetModal = document.querySelector(targetId);
        targetModal.classList.remove('modal-show');
    })
});

 // Initialize form selects
    const initFormSelects = () => {
        document.querySelectorAll('.form-select').forEach(select => {
            select.addEventListener('change', (e) => {
                const wrapper = e.target.closest('.form-select-wrapper');
                if (e.target.value) {
                    wrapper.classList.remove('has-placeholder');
                } else {
                    wrapper.classList.add('has-placeholder');
                }
            });
        });
    };

