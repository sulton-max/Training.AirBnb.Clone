<template>

    <div class="theme-bg-primary w-full px-20 grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-x-5 gap-y-10">

        <ListingCard v-for="_ in 15"/>

    </div>

</template>

<script setup lang="ts">

import ListingCard from './ListingCard.vue';

</script>