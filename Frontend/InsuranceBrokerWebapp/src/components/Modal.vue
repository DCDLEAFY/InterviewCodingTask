<template>
    <div class="modal-backdrop">
        <div class="modal">
            <header class="modal-header">
                <slot name="header">
                    Default Title
                </slot>
                <button type="button" class="btn-close" @click="Close">
                    x
                </button>
            </header>

            <section class="modal-body">
                <slot name="body">
                    Default Body
                </slot>
            </section>

            <footer class="modal-footer">
                <slot name="footer">
                </slot>
                <button type="button" id="submitButton" class="btn-green" @click="DynamicBtn">
                    Submit Modal
                </button>
                <button type="button" class="btn-green" @click="Close">
                    Close Modal
                </button>
            </footer>
        </div>
    </div>
</template>


<script>
export default {
    props: ['dynamicSubmit'],

    methods: {
        Close() {
            this.$emit('Close');
        },
        DynamicBtn(){
            switch (this.dynamicSubmit) {
                case "Close":
                    this.$emit('Close');
                    break;
                case "AddNewCustomer":
                    this.$emit('AddNewCustomer');
                    break;
                case "DeleteCustomer":
                    this.$emit('DeleteCustomer');
                    break;
                case "EditCustomer":
                    this.$emit('EditCustomer');
                    break;
                default:
                    console.log(this.dynamicSubmit);
                    break;
            }

        },
    },
};
</script>

<style scoped>
.modal-backdrop {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0, 0, 0, 0.4);
    display: flex;
    justify-content: center;
    align-items: center;
    font-family: 'Raleway', sans-serif;
}

.modal {
    position: absolute;
    width: 700px;
    height: 450px;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
    background: #FFFFFF;
    box-shadow: 2px 2px 20px 1px;
    overflow-x: auto;
    display: flex;
    flex-direction: column;
}

.modal-header,
.modal-footer {
    padding: 15px;
    display: flex;
}

.modal-header {
    position: relative;
    border-bottom: 1px solid #eeeeee;
    color: #4AAE9B;
    justify-content: space-between;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    font-size: 1.4em;
}

.modal-footer {
    border-top: 1px solid #eeeeee;
    flex-direction: column;
    justify-content: flex-end;
}

.modal-body {
    position: relative;
    padding: 20px 10px;
    align-items: center;
}

.btn-close {
    position: absolute;
    top: 0;
    right: 0;
    border: none;
    font-size: 20px;
    padding: 10px;
    cursor: pointer;
    font-weight: bold;
    color: #4AAE9B;
    background: transparent;
}

.btn-green {
    color: white;
    background: #4AAE9B;
    border: 1px solid #4AAE9B;
    border-radius: 2px;
}
</style>
