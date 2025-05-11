document.querySelectorAll('.form-select').forEach((select) => {
    const trigger = select.querySelector('.form-select-trigger');
    const triggerText = select.querySelector('.form-select-trigger-text');
    const options = select.querySelectorAll('.form-select-option');
    const hiddenInput = select.querySelector('input[type="hidden"]');
    const placeholder = select.dataset.placeholder || 'Select an option';

    const setValue = (value = '', text = placeholder) => {
        hiddenInput.value = value;
        triggerText.textContent = text;
        select.classList.toggle('has-placeholder', !value);
    }
    setValue();
    trigger.addEventListener('click', (e) => {
        e.stopPropagation();
        document.querySelectorAll('.form-select.open').forEach(el =>  el !== select && el.classList.remove('open'));
        select.classList.toggle('open');
    });

    options.forEach((option) => {
        option.addEventListener('click', (e) => {
            e.stopPropagation();
            const value = option.dataset.value;
            const text = option.textContent;
            setValue(value, text);
            select.classList.remove('open');
        });
    });
    document.addEventListener('click', () => {
        select.classList.remove('open');
    });
})