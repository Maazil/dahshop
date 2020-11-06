<template>
    <div>
        <li>
            <h3>{{ name }}</h3>
            <p>Color: {{ color }}</p>
            <p>Size: {{ size }}</p>
            <p>Location: {{ location }}</p>
            <h4>Price: {{ price }} kr</h4>
            <p> Description: {{ description }}</p>
            <div>
                <base-button mode="outline">View details</base-button>
            </div>
        </li>
    </div>
</template>

<script>
export default {
    props: ['id', 'name', 'color', 'size', 'price', 'location', 'description'],
    computed: {
        //....
    }
}
</script>

<style scoped>
li {
  margin: 1rem 0;
  border: 1px solid #424242;
  border-radius: 12px;
  padding: 1rem;
}

h3 {
  font-size: 1.5rem;
}

h3,
h4 {
  margin: 0.5rem 0;
}

div {
  margin: 0.5rem 0;
}

.actions {
  display: flex;
  justify-content: flex-end;
}
</style>
