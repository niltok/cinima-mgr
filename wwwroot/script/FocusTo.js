function focusTo(id) {
    setTimeout(() => {
        let e = document.getElementById(id)
        if (e) {
            e.focus()
            e.scrollTo()
        }
    }, 1000)
}