<template>
    <section>
        <base-card>
        <h3 class="center">Post an item!</h3>
        <item-form></item-form>
        </base-card>
    </section>
</template>

<script>
import ItemForm from '../../components/items/ItemForm.vue';
export default {
    components: {
        ItemForm
    }
}
</script>

<style scoped>
.center{
    margin-left: auto;
    margin-right: auto;
    width: 9rem;
}
</style>