window.antdesign = {

    tooltip: function (tooltip, target, placement, mouseEnterDelay, mouseLeaveDelay, triggers) {
        let popperInstance = null;

        function create() {
            popperInstance = Popper.createPopper(target, tooltip, {
                placement: placement,
            });
        }
        function destroy() {
            if (popperInstance) {
                popperInstance.destroy();
                popperInstance = null;
            }
        }

        function show() {
            setTimeout(() => {
                tooltip.classList.remove('ant-tooltip-hidden');;
                target.classList.add('ant-tooltip-open');;
                create();
            }, mouseEnterDelay);
        }

        function hide() {
            setTimeout(() => {
                tooltip.classList.add('ant-tooltip-hidden');;
                target.classList.remove('ant-tooltip-open');;
                destroy();
            }, mouseLeaveDelay);
        }
        function toggle() {
            if (target.classList.contains("ant-tooltip-open")) {
                hide();
            } else {
                show();
            }
        }
        const showEvents = [];
        const hideEvents = [];

        if (triggers.includes("hover")) {
            showEvents.push("mouseenter")
            hideEvents.push("mouseleave")
        }

        if (triggers.includes("focus")) {
            showEvents.push("focusin")
            hideEvents.push("focusout")
        }

        showEvents.forEach(event => {
            target.addEventListener(event, show);
        });

        hideEvents.forEach(event => {
            target.addEventListener(event, hide);
        });

        if (triggers.includes("click")) {
            target.addEventListener("click",toggle)
        }
    },
}