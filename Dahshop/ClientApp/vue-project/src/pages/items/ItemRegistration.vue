<template>
    <section>
        <base-card>
        <h2 class="center">Post an item!</h2>
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