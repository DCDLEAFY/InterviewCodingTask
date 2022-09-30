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
                <form action="" class="col-auto">
                    <button type="button" id="submitButton" class="btn-modal" @click="DynamicBtn">
                    Submit Modal
                    </button>
                    <button type="button" class="btn-modal" @click="Close">
                        Close Modal
                    </button>
                </form>
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
    width: 650px;
    height: 450px;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
    background: #FFFFFF;
    box-shadow: 2px 2px 20px 1px;
    overflow-x: auto;
    display: flex;
    flex-direction: column;
    overflow-x: hidden;
    border-radius: 0.5em;
}

.modal-header,
.modal-footer {
    padding: 15px;
    display: flex;
}

.modal-header {
    position: relative;
    border: hidden;
    /* border-bottom: 1px solid #eeeeee; */
    color: white;
    justify-content: space-between;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    font-size: 1.4em;
    background-color: #ce5f5f;
}

.modal-footer {
    /* border-top: 1px solid #eeeeee; */
    flex-direction: column;
    justify-content: flex-end;
    border: hidden;
    background-color: #222222;
}

.modal-body {
    position: relative;
    padding: 20px 10px;
    align-items: center;
    background-color: #222222;
    color: white;
    border: hidden;
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

.btn-modal {
    color: white;
    background: #da7171;
    /* border: 1px solid #4AAE9B; */
    border-radius: 2px;
    border-radius: 1em;
    border: hidden;
    margin-inline: 90px;
}


</style>
