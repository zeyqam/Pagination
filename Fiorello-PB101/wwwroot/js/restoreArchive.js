document.addEventListener('DOMContentLoaded', () => {
    let categoryArchiveBtns = document.querySelectorAll('.add-archive');
    Array.from(categoryArchiveBtns).forEach(item => {
        item.addEventListener("click", function () {
            let id = parseInt(this.getAttribute("data-id"));
            let token = document.querySelector('input[name="__RequestVerificationToken"]').value;

            (async () => {
                try {
                    const rawResponse = await fetch(`/Admin/Archive/RestoreFromArchive`, {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json',
                            'RequestVerificationToken': token
                        },
                        body: JSON.stringify({ id: id })
                    });

                    if (!rawResponse.ok) {
                        throw new Error('Network response was not ok');
                    }

                    // Redirect to the CategoryArchive view after restoring the category
                    window.location.href = '/Admin/Archive/CategoryArchive';
                } catch (error) {
                    console.error('There was a problem with the fetch operation:', error);
                }
            })();
        });
    });
});
